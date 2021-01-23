    // List requests by hour
    var q = new W3CReader(textReader).Read()
    			 .GroupBy(r => r.UtcTime().RoundUp(TimeSpan.FromHours(1)))
    			 .Select(g => new
    			 {
    				 	Hour = g.Key,
    					Count = g.Count()
    			 });
    foreach (var r in q)
    {
    	Console.WriteLine("{0}\t{1}", r.Hour, r.Count);
    }
