    static class StringMeasurer
    {
    	private static SizeF GetScaleTransform(Matrix m)
    	{
    		/*
    		 3x3 matrix, affine transformation (skew - used by rotation)
    		 [ X scale,     Y skew,      0 ]
    		 [ X skew,      Y scale,     0 ]
    		 [ X translate, Y translate, 1 ]
    		 
    		 indices (0, ...): X scale, Y skew, Y skew, X scale, X translate, Y translate
    		 */
    		return new SizeF(m.Elements[0], m.Elements[3]);
    	}
    
    	public static RectangleF MeasureString(Graphics graphics, Font f, string s)
    	{
    		//copy only scale, not rotate or transform
    		var scale = GetScaleTransform(graphics.Transform);
    
    		// Get initial estimate with MeasureText
    		//TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.NoClipping;
    		//Size proposedSize = new Size(int.MaxValue, int.MaxValue);
    		//Size size = TextRenderer.MeasureText(graphics, s, f, proposedSize, flags);
    		SizeF sizef = graphics.MeasureString(s, f);
    		sizef.Width *= scale.Width;
    		sizef.Height *= scale.Height;
    		Size size = sizef.ToSize();
    
    		int xLeft = 0;
    		int xRight = size.Width - 1;
    		int yTop = 0;
    		int yBottom = size.Height - 1;
    
    		// Create a bitmap
    		using (Bitmap image = new Bitmap(size.Width, size.Height))
    		{
    			image.SetResolution(graphics.DpiX, graphics.DpiY);
    
    			StringFormat strFormat = new StringFormat();
    			strFormat.Alignment = StringAlignment.Near;
    			strFormat.LineAlignment = StringAlignment.Near;
    
    			// Draw the actual text
    			using (Graphics g = Graphics.FromImage(image))
    			{
    				g.SmoothingMode = graphics.SmoothingMode;
    				g.TextRenderingHint = graphics.TextRenderingHint;
    				g.Clear(Color.White);
    				g.ScaleTransform(scale.Width, scale.Height);
    				g.DrawString(s, f, Brushes.Black, new PointF(0, 0), strFormat);
    			}
    			// Find the true boundaries of the glyph
    
    			// Find left margin
    			for (;  xLeft < xRight; xLeft++)
    				for (int y = yTop; y <= yBottom; y++)
    					if (image.GetPixel(xLeft, y).ToArgb() != Color.White.ToArgb())
    						goto OUTER_BREAK_LEFT;
    		OUTER_BREAK_LEFT: ;
    
    			// Find right margin
    			for (; xRight > xLeft; xRight--)
    				for (int y = yTop; y <= yBottom; y++)
    					if (image.GetPixel(xRight, y).ToArgb() != Color.White.ToArgb())
    						goto OUTER_BREAK_RIGHT;
    		OUTER_BREAK_RIGHT: ;
    
    			// Find top margin
    			for (; yTop < yBottom; yTop++)
    				for (int x = xLeft; x <= xRight; x++)
    					if (image.GetPixel(x, yTop).ToArgb() != Color.White.ToArgb())
    						goto OUTER_BREAK_TOP;
    		OUTER_BREAK_TOP: ;
    
    			// Find bottom margin
    			for (; yBottom > yTop; yBottom-- )
    				for (int x = xLeft; x <= xRight; x++)
    					if (image.GetPixel(x, yBottom).ToArgb() != Color.White.ToArgb())
    						goto OUTER_BREAK_BOTTOM;
    		OUTER_BREAK_BOTTOM: ;
    		}
    
    		var pt = new PointF(xLeft, yTop);
    		var sz = new SizeF(xRight - xLeft + 1, yBottom - yTop + 1);
    		return new RectangleF(pt.X / scale.Width, pt.Y / scale.Height,
    			sz.Width / scale.Width, sz.Height / scale.Height);
    	}
    }
