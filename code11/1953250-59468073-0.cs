    protected byte[] ApplyResize(byte[] byteArray, int targetSize, Size originalSize = default(Size))
	{
	    using (MemoryStream ms = new MemoryStream(byteArray))
	    {
	        if (targetSize <= 0)
	        {
	            targetSize = 800;
	        }
	        var image = Image.FromStream(ms);
	        var size = default(Size);
	        if (originalSize != default(Size))
	        {
	            size = CalculateDimensions(originalSize, targetSize);
	        }
	        else
	        {
	            size = new Size(targetSize, targetSize);
	        }
		        
	        var resized = new Bitmap(size.Width, size.Height);
	        using (var graphics = Graphics.FromImage(resized))
	        {
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    var destination = new Rectangle(0, 0, size.Width, size.Height);
                    using (ImageAttributes wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destination, 0, 0, originalSize.Width, originalSize.Height, GraphicsUnit.Pixel, wrapMode);
                    }
	        }
	        using (var ms2 = new MemoryStream())
	        {
	            resized.Save(ms2, image.RawFormat);
	            return ms2.ToArray();
	        }
	    }
    }
