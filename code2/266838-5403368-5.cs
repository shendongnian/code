    public T FoldLPixels<T>(Image image, Func<T,Pixel,T> func, T acc){
      var ret = acc;
      for (int x = 0; x < image.Width; x++)
      {
        for (int y = 0; y < image.Height; y++)
        {
              ret = func(ret,image.GetPixel(x,y));
        }
      }
      return ret;
    }
