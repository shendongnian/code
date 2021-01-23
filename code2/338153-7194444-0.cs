    public static class EnumerableExx
    {
    	public static U Let<T,U>(this T source, Func<T,U> f)
    	{
    		return f(source);
    	}
    }
