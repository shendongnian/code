    public static class MyExtensions
    {
    	public static double Product(this IEnumerable<double?> enumerable)
    	{
    		return enumerable
              .Aggregate(1.0, (accumulator, current) => accumulator * current.Value);
    	}
    }
