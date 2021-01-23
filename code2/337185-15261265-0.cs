    public static string GetMimeType(this Image image)
    {
        return image.RawFormat.GetMimeType();
    }
    public static string GetMimeType(this ImageFormat imageFormat)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        return codecs.First(codec => codec.FormatID == imageFormat.Guid).MimeType;
    }
    [TestMethod]
    public void can_get_correct_mime_type()
    {
        Assert.AreEqual("image/jpeg", ImageFormat.Jpeg.GetMimeType());
        Assert.AreEqual("image/gif", ImageFormat.Gif.GetMimeType());
        Assert.AreEqual("image/png", ImageFormat.Png.GetMimeType());
    }
