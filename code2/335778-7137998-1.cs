		public Color AverageColorsWithFor(Color[] ColorsToAverage)
		{
			int AlphaTotal = 0;
			int RedTotal = 0;
			int GreenTotal = 0;
			int BlueTotal = 0;
			foreach (Color AColor in ColorsToAverage)
			{
				AlphaTotal += AColor.A;
				RedTotal += AColor.R;
				GreenTotal += AColor.G;
				BlueTotal += AColor.B;
			}
			double NumberOfColors = ColorsToAverage.Length;
			int AlphaAverage = (int)(AlphaTotal / NumberOfColors);
			int RedAverage = (int)(RedTotal / NumberOfColors);
			int GreenAverage = (int)(GreenTotal / NumberOfColors);
			int BlueAverage = (int)(BlueTotal / NumberOfColors);
			return Color.FromArgb(
				AlphaAverage, RedAverage, GreenAverage, BlueAverage
			);
		}
