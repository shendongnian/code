	static class ColorExtensions
	{
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
