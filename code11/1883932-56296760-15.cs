    private void CreateReport(List<Household> households)
    {
    	//get all unique cars
    	List<string> cars = households.SelectMany(h => h.Cars).Distinct().OrderBy(c => c).ToList();
    	foreach(string c in cars)
    	{
    		Console.WriteLine("Households with {0}: {1}", c, HouseholdsWith(households, c));
    		Console.WriteLine("Households with only {0}: {1}", c, HouseholdsWithOnly(households, c));
    	}
    
    	//Get each unique pair
    	var pairs = households.Where(h => h.Cars.Count > 1).SelectMany(h =>
    	{
    		List<Tuple<string, string>> innerpairs = new List<Tuple<string, string>>();
    		for (int i = 0; i < h.Cars.Count - 1; i++)
    		{
    			for (int j = i + 1; j < h.Cars.Count; j++)
    			{
    				if (string.Compare(h.Cars[i], h.Cars[j]) < 0)
    				{
    					innerpairs.Add(new Tuple<string, string>(h.Cars[i], h.Cars[j]));
    				}
    				else
    				{
    					innerpairs.Add(new Tuple<string, string>(h.Cars[j], h.Cars[i]));
    				}
    			}
    		}
    		return innerpairs;
    	}).Distinct().ToList();
    
    	foreach (var p in pairs)
    	{
    		Console.WriteLine("Households with {0} and {1}: {2}", p.Item1, p.Item2, HouseholdsWith(households, p.Item1, p.Item2));
    	}
    }
