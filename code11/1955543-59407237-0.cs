    public static byte[] GetJpegBytes(byte[] bytes)
    {
    	using (var stream = new MemoryStream(bytes))
    	using (var image = Image.FromStream(stream))
    	using (var targetImage = GetImage(image, image.Width, image.Height))
    	using (var targetStream = new MemoryStream())
    	{
    		targetImage.Save(targetStream, ImageFormat.Jpeg);
    		return targetStream.ToArray();
    	}
    }
    
    private static Bitmap GetImage(Image source, int width, int height)
    {
    	using (var image = new Bitmap(width, height))
    	using (var g = Graphics.FromImage(image))
    	{
            //if the gif is transparent we want the jpg to have white background.
    		g.Clear(Color.White); 
            //Make it pretty
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //Draw the old image
    		g.DrawImage(source, 0, 0, width, height);
    
    		return image;
    	}
    }
