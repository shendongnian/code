    public T[][] MapPixels<T>(Image image, Func<int,int,Pixel,T> func){
      var ret = new T[image.Width][image.Height];
      for (int x = 0; x < image.Width; x++)
      {
        for (int y = 0; y < image.Height; y++)
        {
              ret[x][y] = func(x,y,image.GetPixel(x,y)));
        }
      }
      return ret;
    }
    
