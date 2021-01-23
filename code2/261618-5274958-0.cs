    public static class TypeExtensions
    {
    	public static bool IsArrayOf<T>(this Type type)
    	{
    	     return type == typeof (T[]);
    	}
    } 
