	public BitmapSource ConvertToBitmapSource(UIElement element)
	{
		var target = new RenderTargetBitmap((int)(element.RenderSize.Width), (int)(element.RenderSize.Height), 96, 96, PixelFormats.Pbgra32);
		var brush = new VisualBrush(element);
		var visual = new DrawingVisual();
		var drawingContext = visual.RenderOpen();
		drawingContext.DrawRectangle(brush, null, new Rect(new Point(0, 0),
			new Point(element.RenderSize.Width, element.RenderSize.Height)));
		drawingContext.Close();
		target.Render(visual);
		return target;
	}	
