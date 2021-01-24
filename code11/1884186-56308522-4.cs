	static public IEnumerable<T> MyFunction<T>(Func<T> function, int iteration)
    {
        return Enumerable.Repeat(function, iteration).Select( x => x() );
    }
	
	public static void Main()
	{
		int n = 0;
		
		foreach (var i in MyFunction(() => n++, 10)) Console.WriteLine(i);
	}
