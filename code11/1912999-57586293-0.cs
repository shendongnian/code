    public static BitmapSource GetImage(Visual view, Size size)
    {
        var bitmap = new RenderTargetBitmap(
            (int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
        var visualBrush = new VisualBrush
        {
            Visual = view,
            Stretch = Stretch.None
        };
        var drawingvisual = new DrawingVisual();
        using (var context = drawingvisual.RenderOpen())
        {
            context.DrawRectangle(visualBrush, null, new Rect(size));
        }
        bitmap.Render(drawingvisual);
        return bitmap;
    }
