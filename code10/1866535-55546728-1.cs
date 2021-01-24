    var rect = new Rect(Pad.RenderSize);
    var visual = new DrawingVisual();
    using (var dc = visual.RenderOpen())
    {
        dc.DrawRectangle(new VisualBrush(Pad), null, rect);
    }
    var bitmap = new RenderTargetBitmap(
        (int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Default);
    bitmap.Render(visual);
    Pad.Background = new ImageBrush(bitmap);
    Pad.Children.Clear();
