    private static void SaveVisual(Visual visual, Size size, double dpi, string path)
    {
        var rtb = new RenderTargetBitmap(
            (int)(size.Width * dpi / 96),
            (int)(size.Height * dpi / 96),
            dpi, dpi, PixelFormats.Default);
        rtb.Render(visual);
        var encocer = new JpegBitmapEncoder();
        encocer.Frames.Add(BitmapFrame.Create(rtb));
        using (var stream = File.OpenWrite(path))
        {
            encocer.Save(stream);
        }
    }
