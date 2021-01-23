	private Image CreateBitmapImage(DrawingImage drawingImage)
	{
		var image = new Image();
		image.Source = drawingImage;
		var bitmap = new RenderTargetBitmap(300, 300, 96, 96, PixelFormats.Pbgra32);
		var size = new Size(bitmap.PixelWidth,bitmap.PixelHeight);
		image.Measure(size);
		image.Arrange(new Rect(size));
		bitmap.Render(image);
		image.Source = bitmap;
		return image;
	}
