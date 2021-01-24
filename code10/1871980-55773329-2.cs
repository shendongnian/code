    public void CaptureScreen(UIElement source, double dpi, string destination)
    {
        RenderOptions.SetEdgeMode(source, EdgeMode.Aliased);
        var drawingVisual = new DrawingVisual();
        using (DrawingContext drawingContext = drawingVisual.RenderOpen())
        {
            drawingContext.DrawRectangle(
                new VisualBrush(source),
                null,
                new Rect(source.RenderSize));
        }
        var bitmap = new RenderTargetBitmap(
            (int)Math.Round(source.RenderSize.Width * dpi / 96),
            (int)Math.Round(source.RenderSize.Height * dpi / 96),
            dpi, dpi, PixelFormats.Default);
        bitmap.Render(drawingVisual);
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = new FileStream(destination, FileMode.Create))
        {
            encoder.Save(stream);
        }
    }
