    void Main()
    {
    	var results = Combination(new[] { 5, 6, 8, 7, 3, 1 });
    
    	foreach (var result in results)
    	{
    		Console.WriteLine(result);
    	}
    }
    
    IList<int> Combination(IList<int> inputs)
    {
    	var res = new HashSet<int>();
    	BackTracking(inputs, 0, 0, res);
    	return res.OrderBy(x => x).ToArray();
    }
    void BackTracking(IList<int> inputs, int currentIndex, int currentSum, HashSet<int> hash)
    {
    	if (currentIndex == inputs.Count)
    	{
    		if (currentSum == 0)
    			return;
    
    		hash.Add(currentSum);
    		return;
    	}
    
    	for (int i = currentIndex; i < inputs.Count; i++)
    	{
    		BackTracking(inputs, i + 1, currentSum + inputs[i], hash);
    		BackTracking(inputs, i + 1, currentSum, hash);
    	}
    }
