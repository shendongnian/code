    public static Image Resize(this Image image, Single scale)
    {
      if (image == null)
        return null;
      scale = Math.Max(0.0F, scale);
      Int32 scaledWidth = Convert.ToInt32(image.Width * scale);
      Int32 scaledHeight = Convert.ToInt32(image.Height * scale);
      return image.Resize(new Size(scaledWidth, scaledHeight));
    }
    public static Image Resize(this Image image, Size size)
    {
      if (image == null || size.IsEmpty)
        return null;
      var resizedImage = new Bitmap(size.Width, size.Height, image.PixelFormat);
      resizedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
      using (var g = Graphics.FromImage(resizedImage))
      {
        var location = new Point(0, 0);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(image, new Rectangle(location, size), new Rectangle(location, image.Size), GraphicsUnit.Pixel);
      }
      return resizedImage;
    }
