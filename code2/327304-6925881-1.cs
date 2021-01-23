     public delegate void Transformer(ref int x);
		public static void Transform(int[] values, Transformer t)
		{
			for (int i = 0; i < values.Length; i++)
			{
				t(ref values[i]);
			}
		}
	   static void Square(ref int x)
		{
			x*= x;
		}
		static void Minus(ref int x)
	   {
		   x--;
	   }
