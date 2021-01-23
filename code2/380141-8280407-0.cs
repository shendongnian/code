    public static class ObjectExtensions
    {
      	public static IEnumerable<T> WrapInEnumerable<T>(this T t)
    	{
    		yield return t;
    	}
    }
