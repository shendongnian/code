    var itemsOne = new[] {
    	new { Name = "A", Level = 1 },
    	new { Name = "B", Level = 2 },
    	new { Name = "C", Level = 3 },
    	new { Name = "D", Level = 4 }
    }.ToDictionary(i => i.Name, i => i);
    
    var itemsTwo = new[] {
    	new { Name = "C", Level = 10 },
    	new { Name = "D", Level = 20 },
    	new { Name = "E", Level = 30 },
    	new { Name = "F", Level = 40 }
    }.ToDictionary(i => i.Name, i => i);
    
    var itemsOneLevel = 3;
    var itemsTwoLevel = 30;
    
    var validFromItemsOne = (from item in itemsOne
    						 where item.Value.Level <= itemsOneLevel
    						 select item).ToDictionary(i => i.Key, i => i.Value);
    
    var validFromItemsTwo = from item in itemsTwo
    						where item.Value.Level <= itemsTwoLevel
    						 	&& !validFromItemsOne.ContainsKey(item.Key)
    						select item;
    
    var items = validFromItemsOne
    	.Concat(validFromItemsTwo)
    	.ToDictionary(i => i.Key, i => i.Value);
