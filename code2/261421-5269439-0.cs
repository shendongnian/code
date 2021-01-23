		public static IEnumerable<double> FindPeaks(IEnumerable<double> values, int rangeOfPeaks)
		{
			double peak = 0;
			int decay = 0;
			foreach (var value in values)
			{
				if (value > peak || decay > rangeOfPeaks / 2)
				{
					peak = value;
					decay = 0;
				}
				else
				{
					decay++;
				}
				if (decay == rangeOfPeaks / 2)
					yield return peak;
			}
		}
