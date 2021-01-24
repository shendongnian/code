cs
		static double GetMetric(Pixel a, Pixel b)
		{
			double dR = a.R - b.R;
			double dG = a.G - b.G;
			double dB = a.B - b.B;
			return Math.Sqrt(dR * dR + dG * dG + dB * dB);
		}
Then just create a window search algorithm. Create window in the haste (same size as needle). Then try every possible position of window and calculate window distance as the sum of pixel distances.
You do not recalculate whole window. While moving window to the right, just recalculate and subtract left column (the one which was removed) and calculate and add right (new) column.
Then you need to remember minimal distance and its location and just compare it.
The result is the closest window to the needle. (Depends on used metric).
A simplified example:
cs
		static void Find(Bitmap Haste, Bitmap Needle)
		{
			//Simplified for Haste.Height = Needle.Height
			//But Haste.Width > Needle.Width
			int minX = 0;
			int minY = 0;
			double minMetric = double.MaxValue;
			//Setup first window
			double actualMetric = 0;
			for (int i = 0; i < Needle.Width; i++)
			{
				for (int j = 0; j < Needle.Height; j++)
				{
					actualMetric += GetMatric(Needle.GetPixel(i, j), Haste.GetPixel(i, j));
				}
			}
			minMetric = actualMetric;
			//Move window to the right
			for (int i = 0; i < Haste.Width - Needle.Width; i++)
			{
				for (int j = 0; j < Needle.Height; j++)
				{
					//Subtract left column pixel
					actualMetric -= GetMatric(Needle.GetPixel(i, j), Haste.GetPixel(i, j));
					//Add right column pixel
					actualMetric += GetMatric(Needle.GetPixel(i + Needle.Width, j), Haste.GetPixel(i + Needle.Width, j));
				}
				//Compare
				if(actualMetric < minMetric)
				{
					minX = i;
					minY = 0; // Because Y is fixed while simplification Haste and Needle Height
				}
			}
		}
