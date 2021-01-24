    public void CaptureScreen(UIElement source, string destination)
    {
        RenderOptions.SetEdgeMode(source, EdgeMode.Aliased); // here
        var drawingVisual = new DrawingVisual();
        using (DrawingContext drawingContext = drawingVisual.RenderOpen())
        {
            drawingContext.DrawRectangle(
                new VisualBrush(source),
                null,
                new Rect(source.RenderSize));
        }
        var bitmap = new RenderTargetBitmap(
            (int)Math.Round(source.RenderSize.Width),
            (int)Math.Round(source.RenderSize.Height),
            96, 96, PixelFormats.Default);
        bitmap.Render(drawingVisual);
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = new FileStream(destination, FileMode.Create))
        {
            encoder.Save(stream);
        }
    }
