    byte[] resultingBytes;
    var sizedImage = new Bitmap(103, 67);
    using(var stream = new MemoryStream())
    using(var graphicsFromSizedImage = Graphics.FromImage(sizedImage))
    using(var metafile = new Metafile(stream, graphicsFromSizedImage.GetHdc()))
    {
        using(var graphics = Graphics.FromImage(metafile))
        {
            graphics.DrawStuff()
            graphicsFromSizedImage.ReleaseHdc();
        }
        resultingBytes = stream.ToArray();
    }
    File.WriteAllBytes("result.emf", resultingBytes);
