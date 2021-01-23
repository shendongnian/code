		public Color AverageColorsWithLINQ(Color[] ColorsToAverage)
		{
			// the LINQ way
			int AlphaAverage = (int)ColorsToAverage.Average(c => c.A);
			int RedAverage = (int)ColorsToAverage.Average(c => c.R);
			int GreenAverage = (int)ColorsToAverage.Average(c => c.G);
			int BlueAverage = (int)ColorsToAverage.Average(c => c.B);
			return Color.FromArgb(
				AlphaAverage, RedAverage, GreenAverage, BlueAverage
			);
		}
