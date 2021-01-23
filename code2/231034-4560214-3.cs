    public static void SaveAsPng(RenderTargetBitmap src, Stream outputStream)
    {
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(src));
        encoder.Save(outputStream);   
    }
