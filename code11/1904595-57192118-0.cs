    public byte[] GetPng(string filename)
    {
        using (var bitmap = new Bitmap(filename))
        using (var stream = new MemoryStream())
        {
            bitmap.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }
    }
