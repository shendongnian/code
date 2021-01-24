    var list = new List<Tuple<object, int, int>> // item2 - UserId, item3 - InviterId
    	        {
    				new Tuple<object, int, int>(new { Name = "Ivan", Role = "Bidder" }, 1, 12),
    				new Tuple<object, int, int>(new { Name = "George", Role = "Guest" }, 2, 3),
    				new Tuple<object, int, int>(new { Name = "Phil", Role = "Bidder" }, 3, 12),
    				new Tuple<object, int, int>(new { Name = "John", Role = "Guest" }, 4, 3),
    				new Tuple<object, int, int>(new { Name = "Giggs", Role = "Guest" }, 5, 1),
    				new Tuple<object, int, int>(new { Name = "Higgins", Role = "Guest" }, 6, 1),
    				new Tuple<object, int, int>(new { Name = "Alone", Role = "Guest" }, 7, 111),
    				new Tuple<object, int, int>(new { Name = "Alone2", Role = "Guest" }, 8, 112),
    			};
    	
    		var dict = new Dictionary<int, List<object>>();
    		
    		foreach (var element in list)
    		{
    			if (!dict.ContainsKey(element.Item2))
    			{
    				dict.Add(element.Item2, new List<object> { element.Item1 });
    			}
    		}
    	
    		foreach (var element in list)
    		{
    			if (dict.ContainsKey(element.Item3))
    			{
    				dict[element.Item3].Add(element);
    			}
    		}
    	
    		dict.Where(d => d.Value.Count() > 1).ToDictionary(kvp => kvp.Key, kvp => kvp.Value).Dump();
