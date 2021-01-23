    for(int y = 0; y < bmp.Height; y += 2)
        {
           for(int x = 0; x < bmp.Width; x++)
           {
              var pixel = bmp.GetPixel(x,y);
           }
    
           for(int x = bmp.Width; x >= 0; --x)
           {
              var pixel = bmp.GetPixel(x,y+1);
           }
        }
