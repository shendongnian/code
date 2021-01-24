	public static class Ex
	{
		public static double SumOtherIfFirstLessThanEqual25(this IEnumerable<(TextBox first, TextBox other)> source)
		{
			return source.Where(x => double.Parse(x.first.Text) <= 25.0).Sum(x => double.Parse(x.other.Text));
		}
	}
