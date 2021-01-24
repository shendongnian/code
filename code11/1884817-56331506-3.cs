    public static void SaveElement(UIElement element, double dpi, string path)
    {
        var visual = new DrawingVisual();
        using (var context = visual.RenderOpen())
        {
            context.DrawRectangle(
                new VisualBrush(element), null, new Rect(element.RenderSize));
        }
        var bitmap = new RenderTargetBitmap(
            (int)(element.RenderSize.Width * dpi / 96),
            (int)(element.RenderSize.Height * dpi / 96),
            dpi, dpi, PixelFormats.Default);
        bitmap.Render(visual);
        var encocer = new JpegBitmapEncoder();
        encocer.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = File.OpenWrite(path))
        {
            encocer.Save(stream);
        }
    }
