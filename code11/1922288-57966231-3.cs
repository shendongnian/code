	var items = new Item[] {
		new Item { Name = "Jeff", Amount = "20" },
		new Item { Name = "Jack", Amount = "19" },
		new Item { Name = "Ben", Amount = "16" },
		new Item { Name = "Kyle", Amount = "12" }		
	};
	
	var ceilings = GetRangeCeilings(items).ToArray();
	var groupings = items.GroupBy(item => ceilings.First(ceiling => ceiling >= int.Parse(item.Amount)));
