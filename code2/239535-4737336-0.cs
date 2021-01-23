    	// GDI+ has problems with lots of image formats, and it also chokes on unknown ones (like CMYK).
	// Therefore, we're going to take a whitelist approach.
	// see http://bmpinroad.blogspot.com/2006/04/file-formats-pixel-formats.html
	// also see http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/c626a478-e5ef-4a5e-9a73-599b3b7a6ecc
	PixelFormat format = originalImage.PixelFormat;
	if (format == PixelFormat.Format16bppArgb1555 ||
		format == PixelFormat.Format64bppArgb)
	{
		// try to preserve transparency
		format = PixelFormat.Format32bppArgb;
	}
	else if (format == PixelFormat.Format64bppPArgb)
	{
		// try to preserve pre-multiplied transparency
		format = PixelFormat.Format32bppPArgb;
	}
	else if (format != PixelFormat.Format24bppRgb && format != PixelFormat.Format32bppRgb)
	{
		format = PixelFormat.Format24bppRgb;
	}
	// GIF saving is probably still an issue.  If we ever need to tackle it, see the following:
	// http://support.microsoft.com/kb/319061
	// http://www.bobpowell.net/giftransparency.htm
	// http://support.microsoft.com/kb/318343
	using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, format))
	{
		using (Graphics Canvas = Graphics.FromImage(newImage))
		{
			using (ImageAttributes attr = new ImageAttributes())
			{
				attr.SetWrapMode(WrapMode.TileFlipXY);
				Canvas.SmoothingMode = SmoothingMode.AntiAlias;
				Canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
				Canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
				Canvas.DrawImage(originalImage, new Rectangle(new Point(0, 0), newSize), srcRect.X, srcRect.Y, srcRect.Width, srcRect.Height, GraphicsUnit.Pixel, attr);
				newImage.Save(outputImageStream, originalImage.RawFormat);
			}
		}
	}
