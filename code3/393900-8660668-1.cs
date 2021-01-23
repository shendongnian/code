    // Convert to Format24bppRgb
    private static Bitmap Get24bppRgb(Image image)
    {
    	var bitmap = new Bitmap(image);
    	var bitmap24 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format24bppRgb);
    	using (var gr = Graphics.FromImage(bitmap24))
    	{
    		gr.DrawImage(bitmap, new Rectangle(0, 0, bitmap24.Width, bitmap24.Height));
    	}
    	return bitmap24;
    }
