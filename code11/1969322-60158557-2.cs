    public static partial class Extensions
    {
    	public static IEnumerable<T> ToEnumerable<T>(this IEnumerable<T> source)
    	{
    		foreach (var item in source)
    			yield return item;
    	}
    }
