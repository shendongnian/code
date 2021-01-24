    static void Main(string[] args)
    {
    	var preparedQuery = new List<IReadOnlyList<object>>
    	{
    		new List<object> { 100, 10 },
    		new List<object> { 111, 20 },
    		new List<object> { 111, 20 },
    		new List<object> { 112, 30 },
    		new List<object> { 117, 60 },
    		new List<object> { 150, 80 },
    		new List<object> { 170, 90 },
    		new List<object> { 257.527, 200 },
    		new List<object> { 247.527, 100 }
    	}.AsQueryable();
    
    	var list = new List<double>
    	{
    		50, 100, 150, 200, 250, 300
    	};
    
    	var preparedQuery1 = new List<IReadOnlyList<object>>();
    
    	for (int i = 0; i < list.Count; i++)
    	{
    		var s1 = preparedQuery
    					.Where(x => Convert.ToDouble(x[0]) >= list[i] 
    								&& Convert.ToDouble(x[0]) < list[i+1] - 1)
    								.GroupBy(x1 => x1[0])
    					.ToList();
    
    		var s2 = s1.Distinct().ToList(); // not sure this :)
    
    		preparedQuery1.Add(s2);
    	}
    }
