    public abstract static class Calculation
    {
		public struct Context
		{
			public int Constant, SignificantDigits;
			public bool Radians;
		}
		public static int Calculate(int i, Context ctx) { return i * ctx.Constant; }
	}
    // ...
    Calculation.Calculate(123, new Calculate.Context { Constant = 6 });
