    private BitmapSource RenderCrop(Visual element, Rect crop)
    {
        var visualBrush = new VisualBrush
        {
            Visual = element,
            ViewboxUnits = BrushMappingMode.Absolute,
            Viewbox = crop,
            Stretch = Stretch.None
        };
        var drawingVisual = new DrawingVisual();
        using (var dc = drawingVisual.RenderOpen())
        {
            dc.DrawRectangle(visualBrush, null, new Rect(0, 0, crop.Width, crop.Height));
        }
        var bitmap = new RenderTargetBitmap(
            (int)Math.Round(crop.Width), (int)Math.Round(crop.Height),
            96, 96, PixelFormats.Default);
        bitmap.Render(drawingVisual);
        return bitmap;
    }
