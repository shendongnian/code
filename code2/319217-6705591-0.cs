    var sample = new [] {
    	new { Number = 1, Date = DateTime.Now },
    	new { Number = 2, Date = DateTime.Now.AddDays(5) },
    	new { Number = 3, Date = DateTime.Now.AddDays(6) },
    	new { Number = 4, Date = DateTime.Now.AddDays(9) }
    };
    
    var adjacent = sample
    	.Where((o,i) => i>0 && (o.Date.Date - sample[i-1].Date.Date).Days<=1);
    
    Console.WriteLine(string.Join("\n", adjacent));
