    private Dictionary<int, Image> GetImages()
    {
      List<Stream> picsStrm = new List<Stream>();
    
      Assembly asmb = Assembly.GetExecutingAssembly();
      string[] picNames = asmb.GetManifestResourceNames();
    
      foreach (string s in picNames)
      {
        if (s.EndsWith(".png"))
        {
          Stream strm = asmb.GetManifestResourceStream(s);
          if (strm != null)
          {
            picsStrm.Add(strm);
          }
        }
      }
    
      Dictionary<int, Image> images = new Dictionary<int, Image>();
    
      int i = 0;
    
      foreach (Stream strm in picsStrm)
      {
        PngBitmapDecoder decoder = new PngBitmapDecoder(strm,
          BitmapCreateOptions.PreservePixelFormat,
          BitmapCacheOption.Default);
        BitmapSource bitmap = decoder.Frames[0] as BitmapSource;
        Image img = new Image();
        img.Source = bitmap;
        img.Stretch = Stretch.UniformToFill;
        images.Add(i, img);
        i++;
    
        strm.Close();
      }
      return images;
    }
