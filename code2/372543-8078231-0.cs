    public Bitmap ConvertToGrayscale(Bitmap source)
    {
      Bitmap bm = new Bitmap(source.Width,source.Height);
      for(int y=0;y<bm.Height;y++)
      {
        for(int x=0;x<bm.Width;x++)
        {
          Color c=source.GetPixel(x,y);
          int luma = (int)(c.R*0.3 + c.G*0.59+ c.B*0.11);
          bm.SetPixel(x,y,Color.FromArgb(luma,luma,luma));
        }
      }
      return bm;
    }
