    public void VisitPixels<T>(this Image image, Action<int,int,Pixel> func){
      for (int x = 0; x < image.Width; x++)
      {
        for (int y = 0; y < image.Height; y++)
        {
           func(x,y,image.GetPixel(x,y));
        }
      }
    }
