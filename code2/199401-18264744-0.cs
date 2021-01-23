    "TesteDessaBudega".Aggregate(new List<List<char>>(), 
    (l, c) => char.IsUpper(c) ? 
        l.Union(
		    new List<List<char>>(){
				new List<char>(){c}
			}
		).ToList() : 
        l.Take(l.Count - 1).Union(
            new List<List<char>>(){
                l.Last().Union(
                    new List<char>(){c}
				).ToList()
			}
        ).ToList() 
    )
	
