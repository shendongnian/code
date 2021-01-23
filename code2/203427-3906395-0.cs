    using (Image img = Image.FromFile(filename))
    using (Bitmap bmp = new Bitmap(img))
	{
		for (int x = 0; x < img.Width; x++)
		{
			for (int y = 0; y < img.Height; y++)
			{
				Color c = bmp.GetPixel(x, y);
				if (c.R == 255 && c.G == 255 && c.B == 255)
					bmp.SetPixel(x, y, Color.FromArgb(0));
			}
		}
		bmp.Save("out.png", ImageFormat.Png);
	}
