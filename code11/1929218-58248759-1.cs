    private static Dictionary<T, int> StuffToDictionary<T>(IEnumerable<T> input) 
    {
    	var dict = new Dictionary<T, int>();
	  foreach (var key in input)
	  {
		if (dict.ContainsKey(key)) 
		{
			dict[key]++;
		}
		else
		{
			dict[key]=1;
		}
	  }
	  return dict;
    }
