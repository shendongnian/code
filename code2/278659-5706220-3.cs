    public static class Lulz
    {
    	public static List<int> MiddlePercentage(this List<int> ints, double Percentage)
    	{
    		int min = ints.Min();
    		double range = (ints.Max() - min);
    		
    		var results = ints.Select(o => new { IntegralValue = o, Weight = (o - ints.Min()) / range} );
    		
    		double tolerance = (1 - Percentage) / 2;
    		return results.Where(o => o.Weight >= tolerance && o.Weight < 1 - tolerance).Select(o => o.IntegralValue).ToList();
    	}
    }
