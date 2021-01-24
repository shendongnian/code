    private PositionToClick IsInCapture(Bitmap searchFor, Bitmap searchIn)
	{
		var searchForArray = ImageToByte2(searchFor);
		var searchInArray = ImageToByte2(searchIn);
    	for (int x = 0; x <= searchIn.Width - searchFor.Width; x++)
    	{
			for (int y = 0; y <= searchIn.Height - searchFor.Height; y++)
			{
				bool invalid = false;
				int k = x, l = y;
				for (int a = 0; a < searchFor.Width; a++)
				{
					l = y;
					for (int b = 0; b < searchFor.Height; b++)
					{
						var pixelFor = searchForArray[a * searchFor.Width + b];
						var pixelIn = searchInArray[k + searchIn.Width + l];
						if (pixelIn != pixelFor)
						{
							invalid = true;
							break;
						}
						else
							l++;
					}
					if (invalid)
						break;
					else
						k++;
				}
				if (!invalid)
					return new PositionToClick() { X = x, Y = y, found = true };
			}
    	}
		return new PositionToClick();
	}
	
	public static byte[] ImageToByte2(Image img)
	{
		using (var stream = new MemoryStream())
		{
			img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
			return stream.ToArray();
		}
	}
