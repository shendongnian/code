    public static Image Compress(this Image image, Int32 quality)
    {
      if (image == null)
        return null;
      quality = Math.Max(0, Math.Min(100, quality));
      using (var encoderParameters = new EncoderParameters(1))
      {
        var imageCodecInfo = ImageCodecInfo.GetImageEncoders().First(encoder => String.Compare(encoder.MimeType, "image/jpeg", StringComparison.OrdinalIgnoreCase) == 0);
        var memoryStream = new MemoryStream();
        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, Convert.ToInt64(quality));
        image.Save(memoryStream, imageCodecInfo, encoderParameters);
        return Image.FromStream(memoryStream);
      }
    }
