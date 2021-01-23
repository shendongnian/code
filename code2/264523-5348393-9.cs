    static byte[] ReSize(string Img, int Width, int Height, int Hori, int Verti)
    {
      try
      {
        using (SD.Image OriginalImage = SD.Image.FromFile(Img))
        {
          using (SD.Bitmap bmp = new SD.Bitmap(Width, Height))
          {
            bmp.SetResolution(OriginalImage.HorizontalResolution,  OriginalImage.VerticalResolution);
            using (SD.Graphics Graphic = SD.Graphics.FromImage(bmp))
            {
              Graphic.SmoothingMode = SmoothingMode.AntiAlias;
              Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
              Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
              Graphic.DrawImage(OriginalImage, new SD.Rectangle(0, 0, Width, Height), Hori, Verti, Width, Height, SD.GraphicsUnit.Pixel);
    
              MemoryStream ms = new MemoryStream();
              bmp.Save(ms, OriginalImage.RawFormat);
              return ms.GetBuffer();
            }
          }
        }
      }
      catch (Exception ex)
      {
        //Handle ex here
      }
    }
