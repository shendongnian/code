    public void ImageToBytes(Image image, ImageFormat format)
    {
      var stream = new MemoryStream();
      image.Save(stream, format);
      return stream.ToArray();
    }
