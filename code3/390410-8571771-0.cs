    private unsafe byte[] BmpToBytes_Unsafe (Bitmap bmp)
    {
    	BitmapData bData = bmp.LockBits(new Rectangle (new Point(), bmp.Size),
    		ImageLockMode.ReadOnly, 
    		PixelFormat.Format24bppRgb);
    	// number of bytes in the bitmap
    	int byteCount = bData.Stride * bmp.Height;
    	byte[] bmpBytes = new byte[byteCount];
    
    	// Copy the locked bytes from memory
    	Marshal.Copy (bData.Scan0, bmpBytes, 0, byteCount);
    
    	// don't forget to unlock the bitmap!!
    	bmp.UnlockBits (bData);
    
    	return bmpBytes;
    }
