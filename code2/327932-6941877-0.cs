    private static int[] ConvertTextToIntArray(string text)
    {
    	var integerList = new List<int>();
    	var values = text.Split(',');
    	int temp;
    
    	foreach (var value in values)
    	{
    		if (int.TryParse(value, out temp))
    		{
    			integerList.Add(temp);
    		}
    	}
    
    	return integerList.ToArray();
    }
