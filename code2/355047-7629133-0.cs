   	unsafe void Main()
	{
		Bitmap bm = (Bitmap)Image.FromFile("D:\\word.png");
		var locked = bm.LockBits(new Rectangle(0,0,bm.Width, bm.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
		try 
		{
			byte v = 0xaa;
			byte* pBuffer = (byte*)locked.Scan0;
			for(int r = 0 ; r < locked.Height ; r++) 
			{
				byte* row = pBuffer + r*locked.Stride;
				for(int c = 0 ; c < locked.Stride ; c++) 
					row[c] = v;
			}
		}
		finally
		{
			bm.UnlockBits(locked);
		}
		bm.Save("D:\\generated.png");
	}
