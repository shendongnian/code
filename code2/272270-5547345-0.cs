    using (var context = new NorthwindDataContext())
    {
      var allOrders = from p in db.Orders
                   select new { p.OrderID, p.OrderDate };
    
      // Here you can do further processing (to be executed in DB)
      var someOrders = allOrders.Where(ao => ao.OrderDate < DateTime.Today.AddDays(-1));
      Console.WriteLine(someOrders.Count()); // <-- Query will execute here
    }
