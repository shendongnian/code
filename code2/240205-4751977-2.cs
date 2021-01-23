	static class ColorExtensions
	{
		public static bool Between(this Color c, Color a, Color b)
		{
			// replace following with whatever logic you need
			return c.A >= a.A && c.A <= b.A &&
			   c.R >= a.R && c.R <= b.R &&
			   c.G >= a.G && c.G <= b.G &&
			   c.B >= a.B && c.B <= b.B;
		}
		public static bool LessOrEqual(this Color a, Color b)
		{
			// replace following with whatever logic you need
			return a.A <= b.A &&
			   a.R <= b.R &&
			   a.G <= b.G &&
			   a.B <= b.B;
		}
		public static bool MoreOrEqual(this Color a, Color b)
		{
			// replace following with whatever logic you need
			return a.A >= b.A &&
			   a.R >= b.R &&
			   a.G >= b.G &&
			   a.B >= b.B;
		}
	}
