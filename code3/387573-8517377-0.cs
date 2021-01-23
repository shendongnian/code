    int w = imgObj.GetAsNumber(PdfName.WIDTH).IntValue;
    int h = imgObj.GetAsNumber(PdfName.HEIGHT).IntValue;
    int bpp = imgObj.GetAsNumber(PdfName.BITSPERCOMPONENT).IntValue;
    var pixelFormat = PixelFormat.Format1bppIndexed;
    
    byte[] rawBytes = PdfReader.GetStreamBytesRaw((PRStream)imgObj);
    byte[] decodedBytes = PdfReader.FlateDecode(rawBytes);
    byte[] streamBytes = PdfReader.DecodePredictor(decodedBytes, imgObj.GetAsDict(PdfName.DECODEPARMS));
    // byte[] streamBytes = PdfReader.GetStreamBytes((PRStream)imgObj); // same result as above 3 lines of code.
    
    using (Bitmap bmp = new Bitmap(w, h, pixelFormat))
    {
    	var bmpData = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, pixelFormat);
    	int length = (int)Math.Ceiling(w * bpp / 8.0);
    	for (int i = 0; i < h; i++)
    	{
    		int offset = i * length;
    		int scanOffset = i * bmpData.Stride;
    		Marshal.Copy(streamBytes, offset, new IntPtr(bmpData.Scan0.ToInt32() + scanOffset), length);
    	}
    	bmp.UnlockBits(bmpData);
    
    	bmp.Save(fileName);
    }
