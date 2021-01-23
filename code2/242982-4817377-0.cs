    using (Bitmap bm1 = new Bitmap("PB270029.JPG"))
    {
    	Console.WriteLine(bm1.PixelFormat.ToString());
    
    	int width = bm1.Width;
    	int height = bm1.Height;
    	Console.WriteLine("width = " + width + "  height = " + height);
    
    	Rectangle rect1 = new Rectangle(0, 0, width, height);
    	BitmapData bm1Data = bm1.LockBits(rect1, ImageLockMode.ReadOnly, bm1.PixelFormat);
    	try
    	{
    		Console.WriteLine("stride = " + bm1Data.Stride);
    
    		IntPtr bm1Ptr = bm1Data.Scan0;
    
    		int bytes = Math.Abs(bm1Data.Stride) * height;
    		Console.WriteLine("bytes = " + bytes);
    
    		byte[] rgbValues1 = new byte[bytes];
    		Marshal.Copy(bm1Ptr, rgbValues1, 0, bytes);
    
    		Console.WriteLine("After 1st Marshal.Copy ...");
    	}
    	finally
    	{
    		bm1.UnlockBits(bm1Data);
    	}
    }
    
    using (Bitmap bm2 = new Bitmap("PA050164.JPG"))
    {
    	Rectangle rect2 = new Rectangle(0, 0, bm2.Width, bm2.Height);
    	BitmapData bm2Data = bm2.LockBits(rect2, ImageLockMode.ReadOnly, bm2.PixelFormat);
    	try
    	{
    		IntPtr bm2Ptr = bm2Data.Scan0;
    		byte[] rgbValues2 = new byte[Math.Abs(bm2Data.Stride) * bm2.Height];
    		Marshal.Copy(bm2Ptr, rgbValues2, 0, rgbValues2.Length);
    	}
    	finally
    	{
    		bm2.UnlockBits(bm2Data);
    	}
    }
