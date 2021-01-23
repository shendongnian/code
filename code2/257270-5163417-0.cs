    // Bitmap bytes have to be created via a direct memory copy of the bitmap
    private byte[] BmpToBytes_MemStream (Bitmap bmp)
    {
        MemoryStream ms = new MemoryStream();
        // Save to memory using the Jpeg format
        bmp.Save(ms, ImageFormat.Jpeg);
	
        // read to end
        byte[] bmpBytes = ms.GetBuffer();
        bmp.Dispose();
        ms.Close();
        return bmpBytes;
    }
