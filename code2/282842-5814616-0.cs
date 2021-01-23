    // new image with transparent Alpha layer
    using (var bitmap = new Bitmap(330, 18, PixelFormat.Format32bppArgb))
    {
    	using (var graphics = Graphics.FromImage(bitmap))
    	{
    		// add some anti-aliasing
    		graphics.SmoothingMode = SmoothingMode.AntiAlias;
    
    		using (var font = new Font("Arial", 14.0f, GraphicsUnit.Pixel))
    		{
    			using (var brush = new SolidBrush(Color.White))
    			{
    				// draw it
    				graphics.DrawString(user.Email, font, brush, 0, 0);
    			}
    		}
    	}
    
    	// setup the response
    	Response.Clear();
    	Response.ContentType = "image/png";
    	Response.BufferOutput = true;
    
    	// write it to the output stream
    	bitmap.Save(Response.OutputStream, ImageFormat.Png);
    	Response.Flush();
    }
