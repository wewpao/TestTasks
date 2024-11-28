using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;  // Adjust this import if your model is in a different namespace
using OfficeOpenXml;

namespace WebApplication8.Controllers
{
    public class MainController : Controller
    {
        private readonly TestTaskEntities _context;  // Your DbContext class

        // Constructor to initialize the database context
        public MainController()
        {
            _context = new TestTaskEntities();  // Make sure you have this context set up in your project
        }

        //[HttpPost]
        //public ActionResult GetFilteredOrders(Dictionary<string, string> filters)
        //{
        //    var query = _context.Orders.AsQueryable(); // Start with the Orders table

        //    // Dynamically build the WHERE clause based on filters
        //    foreach (var filter in filters)
        //    {
        //        if (!string.IsNullOrEmpty(filter.Value))
        //        {
        //            query = query.Where(order => EF.Property<string>(order, filter.Key) == filter.Value);
        //        }
        //    }

        //    var filteredOrders = query.ToList(); // Execute the query and get the results

        //    // Return the filtered orders as JSON to the view
        //    return PartialView("_OrdersTable", filteredOrders); // Return a partial view with the results
        //}

        // GET: Main
        public ActionResult Index()
        {
            ViewBag.orderResult = _context.Orders;

            // Pickup-related fields
            ViewBag.OrderTypes = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.OrderType))
                .Select(o => o.OrderType)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.ImportOptions = _context.Orders
                .Where(o => o.Import != null)
                .Select(o => o.Import)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupStoreNumbers = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.PickupStoreNumber))
                .Select(o => o.PickupStoreNumber)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupStoreNames = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.PickupStoreName))
                .Select(o => o.PickupStoreName)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupLatitudes = _context.Orders
                .Where(o => o.PickupLatitude != null)
                .Select(o => o.PickupLatitude)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupLongitudes = _context.Orders
                .Where(o => o.PickupLongitude != null)
                .Select(o => o.PickupLongitude)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupFormattedAddresses = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.PickupFormattedAddress))
                .Select(o => o.PickupFormattedAddress)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupContactFirstNames = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.PickupContactFirstName))
                .Select(o => o.PickupContactFirstName)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupContactLastNames = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.PickupContactLastName))
                .Select(o => o.PickupContactLastName)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupContactEmails = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.PickupContactEmail))
                .Select(o => o.PickupContactEmail)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupContactMobileNumbers = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.PickupContactMobileNumber))
                .Select(o => o.PickupContactMobileNumber)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupEnableSMSNotifications = _context.Orders
                .Where(o => o.PickupEnableSMSNotification != null)
                .Select(o => o.PickupEnableSMSNotification)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupTimes = _context.Orders
                .Where(o => o.PickupTime != null)
                .Select(o => o.PickupTime)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupToleranceMinutes = _context.Orders
                .Where(o => o.PickupToleranceMinutes != null)
                .Select(o => o.PickupToleranceMinutes)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.PickupServiceTimes = _context.Orders
                .Where(o => o.PickupServiceTime != null)
                .Select(o => o.PickupServiceTime)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            // Delivery-related fields
            ViewBag.DeliveryStoreNumbers = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.DeliveryStoreNumber))
                .Select(o => o.DeliveryStoreNumber)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryStoreNames = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.DeliveryStoreName))
                .Select(o => o.DeliveryStoreName)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryLatitudes = _context.Orders
                .Where(o => o.DeliveryLatitude != null)
                .Select(o => o.DeliveryLatitude)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryLongitudes = _context.Orders
                .Where(o => o.DeliveryLongitude != null)
                .Select(o => o.DeliveryLongitude)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryFormattedAddresses = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.DeliveryFormattedAddress))
                .Select(o => o.DeliveryFormattedAddress)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryContactFirstNames = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.DeliveryContactFirstName))
                .Select(o => o.DeliveryContactFirstName)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryContactLastNames = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.DeliveryContactLastName))
                .Select(o => o.DeliveryContactLastName)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryContactEmails = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.DeliveryContactEmail))
                .Select(o => o.DeliveryContactEmail)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryContactMobileNumbers = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.DeliveryContactMobileNumber))
                .Select(o => o.DeliveryContactMobileNumber)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryEnableSMSNotifications = _context.Orders
                .Where(o => o.DeliveryEnableSMSNotification != null)
                .Select(o => o.DeliveryEnableSMSNotification)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryTimes = _context.Orders
                .Where(o => o.DeliveryTime != null)
                .Select(o => o.DeliveryTime)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryToleranceMinutes = _context.Orders
                .Where(o => o.DeliveryToleranceMinutes != null)
                .Select(o => o.DeliveryToleranceMinutes)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.DeliveryServiceTimeMinutes = _context.Orders
                .Where(o => o.DeliveryServiceTimeMinutes != null)
                .Select(o => o.DeliveryServiceTimeMinutes)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            // Other order details
            ViewBag.OrderDetails = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.OrderDetails))
                .Select(o => o.OrderDetails)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.AssignedDrivers = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.AssignedDriver))
                .Select(o => o.AssignedDriver)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.CustomerReferences = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.CustomerReference))
                .Select(o => o.CustomerReference)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.Payers = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.Payer))
                .Select(o => o.Payer)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.Vehicles = _context.Orders
                .Where(o => !string.IsNullOrEmpty(o.Vehicle))
                .Select(o => o.Vehicle)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.Weights = _context.Orders
                .Where(o => o.Weight != null)
                .Select(o => o.Weight)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            ViewBag.Prices = _context.Orders
                .Where(o => o.Price != null)
                .Select(o => o.Price)
                .Distinct()
                .OrderBy(o => o)
                .ToList();

            // When accessing the Index action, we'll directly show the Create form.
            return View();
        }

        // Action for importing the Excel file
        [HttpPost]
        public ActionResult ImportOrder(HttpPostedFileBase excelFile)
        {
            if (excelFile != null && excelFile.ContentLength > 0)
            {
                // Validate file type (Optional)
                if (!excelFile.FileName.EndsWith(".xlsx"))
                {
                    ModelState.AddModelError("File", "Please upload a valid Excel file (.xlsx).");
                    return View();
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Read the Excel file
                using (var package = new ExcelPackage(excelFile.InputStream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Read the first sheet

                    // Get the row count
                    int rowCount = worksheet.Dimension.Rows;

                    // Loop through all rows in the worksheet (skipping the header row)
                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            var order = new Order
                            {
                                OrderType = worksheet.Cells[row, 1].Text, // Assuming this can be empty
                                Import = Convert.ToBoolean(worksheet.Cells[row, 2].Text == "1" ? true : false),

                                // Pickup fields with null or empty checks and safe conversions
                                PickupStoreNumber = string.IsNullOrEmpty(worksheet.Cells[row, 3]?.Text) ? null : worksheet.Cells[row, 3].Text,
                                PickupStoreName = string.IsNullOrEmpty(worksheet.Cells[row, 4]?.Text) ? null : worksheet.Cells[row, 4].Text,
                                PickupLatitude = TryParseDecimal(worksheet.Cells[row, 5]?.Text),
                                PickupLongitude = TryParseDecimal(worksheet.Cells[row, 6]?.Text),
                                PickupFormattedAddress = worksheet.Cells[row, 7].Text,
                                PickupContactFirstName = worksheet.Cells[row, 8].Text,
                                PickupContactLastName = worksheet.Cells[row, 9].Text,
                                PickupContactEmail = worksheet.Cells[row, 10].Text,
                                PickupContactMobileNumber = worksheet.Cells[row, 11].Text,
                                PickupEnableSMSNotification = TryParseBoolean(worksheet.Cells[row, 12].Text),
                                PickupTime = TryParseTimeSpan(worksheet.Cells[row, 13]?.Text),
                                PickupToleranceMinutes = TryParseInt32(worksheet.Cells[row, 14]?.Text),
                                PickupServiceTime = TryParseInt32(worksheet.Cells[row, 15]?.Text),

                                // Delivery fields with null or empty checks and safe conversions
                                DeliveryStoreNumber = string.IsNullOrEmpty(worksheet.Cells[row, 16]?.Text) ? null : worksheet.Cells[row, 16].Text,
                                DeliveryStoreName = string.IsNullOrEmpty(worksheet.Cells[row, 17]?.Text) ? null : worksheet.Cells[row, 17].Text,
                                DeliveryLatitude = TryParseDecimal(worksheet.Cells[row, 18]?.Text),
                                DeliveryLongitude = TryParseDecimal(worksheet.Cells[row, 19]?.Text),
                                DeliveryFormattedAddress = worksheet.Cells[row, 20].Text,
                                DeliveryContactFirstName = worksheet.Cells[row, 21].Text,
                                DeliveryContactLastName = worksheet.Cells[row, 22].Text,
                                DeliveryContactEmail = worksheet.Cells[row, 23].Text,
                                DeliveryContactMobileNumber = worksheet.Cells[row, 24].Text,
                                DeliveryEnableSMSNotification = TryParseBoolean(worksheet.Cells[row, 25].Text),
                                DeliveryTime = TryParseTimeSpan(worksheet.Cells[row, 26]?.Text),
                                DeliveryToleranceMinutes = TryParseInt32(worksheet.Cells[row, 27]?.Text),
                                DeliveryServiceTimeMinutes = TryParseInt32(worksheet.Cells[row, 28]?.Text),

                                // OrderDetails and other string fields
                                OrderDetails = worksheet.Cells[row, 29].Text,
                                AssignedDriver = worksheet.Cells[row, 30].Text,
                                CustomerReference = worksheet.Cells[row, 31].Text,
                                Payer = worksheet.Cells[row, 32].Text,
                                Vehicle = worksheet.Cells[row, 33].Text,

                                // Numerical fields with proper checks
                                Weight = TryParseDecimal(worksheet.Cells[row, 34]?.Text),
                                Price = TryParseDecimal(worksheet.Cells[row, 35]?.Text)
                            };

                            // Add the order to the database context
                            _context.Orders.Add(order);
                        }
                        catch (Exception ex)
                        {
                            string err = ex.ToString();
                            // Optionally log the error for debugging purposes
                        }
                    }

                    // Save changes to the database
                    _context.SaveChanges();
                }

                TempData["Message"] = "File imported successfully!";
            }

            return RedirectToAction("Index"); // Redirect to the appropriate view
        }

        // Helper methods to safely parse the data
        private decimal TryParseDecimal(string value)
        {
            decimal result;
            return decimal.TryParse(value, out result) ? result : 0m; // Default to 0 if invalid
        }

        private bool TryParseBoolean(string value)
        {
            bool result;
            return bool.TryParse(value, out result) ? result : false; // Default to false if invalid
        }

        private TimeSpan TryParseTimeSpan(string value)
        {
            TimeSpan result;
            return TimeSpan.TryParse(value, out result) ? result : TimeSpan.Zero; // Default to TimeSpan.Zero if invalid
        }

        private int TryParseInt32(string value)
        {
            int result;
            return int.TryParse(value, out result) ? result : 0; // Default to 0 if invalid
        }
    }
}
