    private Image ResizeImage(Image original, int targetWidth)
	{
		double percent = (double)original.Width / targetWidth;
		int destWidth = (int)(original.Width / percent);
		int destHeight = (int)(original.Height / percent);
		Bitmap b = new Bitmap(destWidth, destHeight);
		Graphics g = Graphics.FromImage((Image)b);
		try
		{
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.DrawImage(original, 0, 0, destWidth, destHeight);
		}
		finally
		{
			g.Dispose();
		}
		return (Image)b;
	}
