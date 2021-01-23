	public void LoadFromBitmap(Bitmap bmp)
		{
			if (bmp.Width != Width || bmp.Height != Height)
				throw new ArgumentException("Size missmatch");
			unsafe
			{
				BitmapData bmpData = null;
				try
				{
					bmpData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
					for (int y = 0; y < bmpData.Height; y++)
					{
						uint* p = (uint*)((byte*)bmpData.Scan0 + y * bmpData.Stride);
						for (int x = 0; x < bmpData.Width; x++)
						{
							this[x, y] = RawColor.FromARGB(*p);
							p++;
						}
					}
				}
				finally
				{
					if (bmpData != null)
						bmp.UnlockBits(bmpData);
				}
			}
		}
