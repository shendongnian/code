    public static byte[] ConvertImageToByteArray(Image imageIn)
    {
        var ms = new MemoryStream();
        imageIn.Save(ms, ImageFormat.Png);
        return ms.ToArray();
    }
