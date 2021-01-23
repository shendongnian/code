	public class A
	{
		public int X { get; set; }
	}
	public class B : A
	{
		public static A operator + (A first, A second)
		{
			// this won't compile because either first or second must be type B...
		}
	}
