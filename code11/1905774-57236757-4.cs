    public static List<ValueTuple<string, string>> OutputCombinations(List<string> list)
    {
	   List<ValueTuple<string, string>> pairs = new List<ValueTuple<string, string>>();
	   ValueTuple<string, string> currentPair = new ValueTuple<string, string>();
	   for (int i = 0; i < list.Count; i++)
	   {
		   currentPair.Item1 = list[i];
		
		   for (int j = 0; j < list.Count; j++)
		   {
			   if (i != j)
			   {
				currentPair.Item2 = list[j];
			
				pairs.Add(currentPair);
			   }
		   }
	   }
	
	return pairs;
    }
