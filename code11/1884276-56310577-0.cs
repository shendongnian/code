    var order = _context.Orders.Where(o => o.Id == new Guid("67972aa1-2bb4-4916-b48b-1fdc3c2f5db9"))
                               .Include(o => o.Items).FirstOrDefault(); // I assumed your `Order` primary key name is `Id`
      order.Items = new List<Item> 
      {
            new Item {  Color = "Green", width = 20d }
      };
    
      _context.SaveChanges();
