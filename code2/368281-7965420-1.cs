    class X<T>
    {
    	public static long F(T t) {
    		return (long)(object)t;		// Ok, but will only work when T is long
    	}
    }
