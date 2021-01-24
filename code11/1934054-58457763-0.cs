    		List<Item> items = new List<Item>();//create list
        items.Add(new Item()
            {
                ItemGroup = "Electric",
                ItemDescription = "Electric Sander",
                Quantity = 7,
                UnitPrice = 59.98f,
            });//add list item
             var totalValue = items.GroupBy(a => new { a.Quantity, a.ItemDescription, a.UnitPrice })
                      .Select(g => new { g.Key.ItemDescription, g.Key.Quantity, g.Key.UnitPrice,
                                         Price = g.Sum(s => (int)g.Key.Quantity * (float)g.Key.UnitPrice)
                                         });
		
		foreach (var Item in totalValue)
        {
            Console.WriteLine("" + Item);
        }
