    public static RenderTargetBitmap GetImage(OverallView view)
    {
        Size size = new Size(view.ActualWidth, view.ActualHeight);
        if (size.IsEmpty)
            return null;
        RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
        DrawingVisual drawingvisual = new DrawingVisual();
        using (DrawingContext context = drawingvisual.RenderOpen())
        {
            context.DrawRectangle(new VisualBrush(view), null, new Rect(new Point(), size));
            context.Close();
        }
        bitmap.Render(drawingvisual);
        return bitmap;
    }
