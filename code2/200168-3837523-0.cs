    var bm = new Bitmap(filename);
    for(int x=0;x<bm.Width;x++)
    {
      for(y=0;y<bm.Height;y++)
      {
        Color oldColor=bm.GetPixel(x,y);
        Color newColor=ModifyHue(oldColor);
        bm.SetPixel(x,y,newColor);    
      }
    }
