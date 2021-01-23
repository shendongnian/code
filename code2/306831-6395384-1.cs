    var customer = context.Customers.Where(c => c.Id == customerId);
    context.Entry(customer)
           .Collection(c => c.Purchases)
           .Query()
           .OrderByDescending(p => p.Date)
           .Take(5)
           .Load();
