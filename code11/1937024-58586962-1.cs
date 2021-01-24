    public static class ListTupleExtension
    {
    	public static List<Tuple<DateTime, double>> CumulativeSum(this List<Tuple<DateTime, double>> sequence, double limit)
    	{
    		List<Tuple<DateTime, double>> result = new List<Tuple<DateTime, double>>();
    		double sum = 0;
    		foreach(var item in sequence)
    		{
    			if (sum <= limit)
    			{
    				sum += item.Item2;
    			}
    			
    			result.Add(new Tuple<DateTime, double>(item.Item1, sum));
    		}
    		
    		return result;
    	}
    }
