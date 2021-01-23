	public static void Test()
	{
		Test((Func<string>)(() => "helllo"));
		Test((Expression<Func<string>>) (() => "hello"));
	}
	public static void Test<T>(Func<T> func)
	{
					
	}
	public static void Test<T>(Expression<Func<T>> expression)
	{
		
	}
