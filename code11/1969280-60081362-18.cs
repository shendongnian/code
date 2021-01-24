    public Image ConvertToJpeg(Image img)
    {
        using (var stream = new MemoryStream())
        {
            img.Save(stream, ImageFormat.Jpeg);
            var bytes = stream.ToArray();
            return (Image)new ImageConverter().ConvertFrom(bytes);
        }
    }
