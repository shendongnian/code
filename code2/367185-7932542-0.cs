	class Foo
	{
		private int c;
		public Foo(Builder builder)
		{
			c = builder.A ?? 0 + builder.B ?? 0;
		}
	}
	class Bar : Foo
	{
		public Bar()
			: base(new Builder().WithA(2).WithB(3).WithPlusOrMinus(false))
		{
			
		}
	}
	public class Builder
	{
		public int? A { get; private set; }
		public int? B { get; private set; }
		public bool? PlusOrMinus { get; private set; }
		public Builder WithA(int a)
		{
			A = a;
			return this;
		}
		public Builder WithB(int b)
		{
			B = b;
			return this;
		}
		public Builder WithPlusOrMinus(bool plusOrMinus)
		{
			if(!plusOrMinus)
			{
				B *= -1;
			}
			return this;
		}
	}
