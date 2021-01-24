    Dictionary<string, string> d1 = new Dictionary<string, string>();
    d1.Add("Joe", "2, Barfield Way");
    d1.Add("Mike", "17, Apollo Avenue");
    d1.Add("Jane", "69, Lance Drive");
            
    Dictionary<string, string> d2 = new Dictionary<string, string>();
    d2.Add("Joe", "2, Barfield Way");
	d2.Add("foo", "bar");
    d2.Add("Jane", "69, Lance Drive");
			
	var d3 = new Dictionary<string, string>();
	d3.Add("hello", "world");
	d3.Add("foo", "bar");
    
	var dicts = new List<Dictionary<string, string>>
	{
	    d1,
		d2,
		d3
    };
    var distinct = dicts.SelectMany(d => d)
						.GroupBy(d => d.Key)
						.Where(d => d.Count() == 1)
						.ToDictionary(k => k.Key, v => v.Select(x => x.Value)
                                                        .First());
			
	foreach (var key in distinct.Keys)
	{
		Console.WriteLine(key + " -> " + distinct[key]);
	}
