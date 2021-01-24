    public static class Extensions
    {
    	public static T PickAlternative<T>(this IEnumerable<T> source,string item,int skipCount)
    	{
    		return source.SkipWhile(x=> !x.Equals(item)).Skip(skipCount).First();
    	}
    }
