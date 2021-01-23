    RenderTargetBitmap rtb = new RenderTargetBitmap(gridWidth, gridHeight, 210, 210, PixelFormats.Pbgra32);
    
    rtb.Render(YourGrid);
    
    // If you need to Crop Anything Out
    CroppedBitmap crop = new CroppedBitmap();
    
    crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, gridWidth, gridHeight));
    
    Bitmap bmpToPrint = BitmapSourceToBitmap(crop);
    
    // Helper Method
    public Bitmap BitmapSourceToBitmap(BitmapSource bs)
    {
    	Bitmap bitmap;
    
    	using (MemoryStream ms = new MemoryStream())
    	{
    		BitmapEncoder enc = new BmpBitmapEncoder();
    		enc.Frames.Add(BitmapFrame.Create(bs));
    		enc.Save(ms);
    		bitmap = new Bitmap(ms);
    	}
    
    	return bitmap;
    }
