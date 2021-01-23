    Byte[] bitmapData = new Byte[ImageText.Length];
    bitmapData = Convert.FromBase64String(FixBase64ForImage(ImageText));
    System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
    Bitmap bitImage = new Bitmap((Bitmap)Image.FromStream(streamBitmap));
    public string FixBase64ForImage(string Image) { 
    System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image,Image.Length);
    sbText.Replace("\r\n", String.Empty); sbText.Replace(" ", String.Empty); 
    return sbText.ToString(); 
    }
