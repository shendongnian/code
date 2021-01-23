    IEnumerable<IEnumerable<int>> sequences = new[] {new[] {1,2,3}, new[] {4,5}, new[] {6,7,8}};
    IEnumerable<IEnumerable<IEnumerable<int>>> prefixSet = new[] {new[] { Enumerable.Empty<int>() }};
    
    for (int i=0; i<sequences.Count(); i++)
    {
    	IEnumerable<IEnumerable<int>> prefixSequence = Enumerable.Empty<IEnumerable<int>>();
    	for (int j=0; j<=i; j++)
    	{
    		prefixSequence = prefixSequence.Concat(new[] { sequences.ElementAt(j) });
    	}
    	prefixSet = prefixSet.Concat(new[] { prefixSequence });
    }
    
    foreach (IEnumerable<IEnumerable<int>> item in prefixSet)
    {
    	Console.WriteLine(item.CartesianProduct<int>());
    }
