    var dict = new Dictionary<string, decimal>();
    
    dict.Add("A", 1.5m); // This value will be skipped
    dict.Add("B", 2.7m);
    dict.Add("C", 1.3m);
    dict.Add("D", 3.9m);
	
    var total = dict.Skip(1).Sum(v => v.Value);
	
    Console.WriteLine(total);
