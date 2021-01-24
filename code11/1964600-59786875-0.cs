    [HttpGet]
    public IActionResult Get(DataSourceLoadOptions loadOptions)
    {
        loadOptions.PrimaryKey = new[] { "OrderID" };
        var orders = from o in _db.Orders
            select new
            {
                o.OrderID,
                o.CustomerID,
                CustomerName = o.Customer.ContactName,
                o.EmployeeID,
                EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName,
                o.OrderDate,
                o.RequiredDate,
                o.ShippedDate,
                o.ShipVia,
                ShipViaName = o.Shipper.CompanyName,
                o.Freight,
                o.ShipName,
                o.ShipAddress,
                o.ShipCity,
                o.ShipRegion,
                o.ShipPostalCode,
                o.ShipCountry
            };
        return new OkObjectResult(DataSourceLoader.Load(orders, loadOptions));
    }
