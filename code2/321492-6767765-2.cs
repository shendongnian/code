	public class A
	{
		public int X { get; set; }
	}
	public class B : A
	{
		public static B operator + (B first, B second)
		{
			// You could do this, but then you'd have to use the subclass B everywhere you wanted to
			// do this instead of the original class A, which may be undesirable...
		}
	}
