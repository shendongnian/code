    static class ArrayExtensions
    {
    	public static int FindIndex<T>(this T[] array, Predicate<T> match)
    	{
    		return Array.FindIndex(array, match);
    	}
    }
