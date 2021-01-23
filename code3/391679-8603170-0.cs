    IEnumerable<MyData> source = new List<MyData>();
    var names = source
    	.GroupBy(item => item.Name)
    	.ToDictionary(item => item.Key, item => item.Sum(i => i.Quantity))
    	.OrderByDescending(item => item.Value)
    	.Select(item => item.Key)
    	.Take(2)
    	.ToList();
    
    var result = source.Where(item => names.Contains(item.Name));
