    void Main()
    {
    	var results = Combination(new[] {2, 5, 6, 8, 7, 3, 1});
    
    	foreach (var result in results.OrderBy(x => x.Count))
    	{
    		Console.WriteLine($"{string.Join(",", result)} = {result.Sum()}");
    	}
    }
    
    IList<IList<int>> Combination(IList<int> inputs)
    {
    	var res = new List<IList<int>>();
    	BackTracking(inputs, 0, res, new List<int>());
    
    	return res;
    }
    void BackTracking(IList<int> inputs, int currentIndex, IList<IList<int>> result, IList<int> currentCombo)
    {
    	if (currentIndex == inputs.Count)
    	{
    		if (currentCombo.Count != 0)
    			result.Add(currentCombo.ToList());
    		return;
    	}
    
    	BackTracking(inputs, currentIndex + 1, result, currentCombo.ToList());
    	currentCombo.Add(inputs[currentIndex]);
    	BackTracking(inputs, currentIndex + 1, result, currentCombo.ToList());
    }
