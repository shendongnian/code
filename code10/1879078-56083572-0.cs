	void Main()
	{
		var path = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
			"images");
		
		var original = new Image<Bgr, Byte>(Path.Combine(path, "vz7Oo1W.png"));
		var mask = new Image<Bgr, Byte>(Path.Combine(path, "vIQUvUU.png"));
	
		var bitmap = new Bitmap(original.Width, original.Height);
		using (Graphics g = Graphics.FromImage(bitmap))
		{
			g.DrawImage(original.Bitmap, 0, 0);
			g.DrawImage(MakeTransparent(mask.Bitmap), 0, 0);
		}
		bitmap.Save(Path.Combine(path, "new.png"));
	}
	
	public static Bitmap MakeTransparent(Bitmap image)
	{
		Bitmap b = new Bitmap(image);
	
		var tolerance = 10;
	
		for (int i = b.Size.Width - 1; i >= 0; i--)
		{
			for (int j = b.Size.Height - 1; j >= 0; j--)
			{
				var col = b.GetPixel(i, j);
				col.Dump();
	
				if (255 - col.R < tolerance &&
					255 - col.G < tolerance &&
					255 - col.B < tolerance)
				{
					b.SetPixel(i, j, Color.Transparent);
				}
			}
		}
	
		return b;
	}
