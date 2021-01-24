    IEnumerable<int> GetRangeCeilings(IEnumerable<Item> input)
    {
        const int maximumAllowedDistance = 1;
    	var amounts = input.Select(x => int.Parse(x.Amount)).OrderBy(x => x).ToArray();
    	for (var i = 1; i < amounts.Length; i ++)
    	{
    		if (amounts[i - 1] < amounts[i] - maximumAllowedDistance)
    		{
    			yield return amounts[i - 1];
    		}
    	}
    	yield return int.MaxValue;
    }
