    string ImageToBase64(BitmapSource bitmap)
    {
        var encoder = new PngBitmapEncoder();
        var frame = BitmapFrame.Create(bitmap);
        encoder.Frames.Add(frame);
        using(var stream = new MemoryStream())
        {
            encoder.Save(stream);
            return Convert.ToBase64String(stream.ToArray());
        }
    }
    BitmapSource Base64ToImage(string base64)
    {
        byte[] bytes = Convert.FromBase64String(base64);
        using(var stream = new MemoryStream(bytes))
        {
            return BitmapFrame.Create(stream);
        }
    }
