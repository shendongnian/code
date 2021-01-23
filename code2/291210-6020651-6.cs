    for(int y = 0; y < bmp.Height; y += 2)
        {
           for(int x = 0; x < bmp.Width; x++)
           {
              var pixel = bmp.GetPixel(x,y);
           }
    
           var line = y + 1;
           if(line < bmp.Height)
           {
             for(int x = bmp.Width; x >= 0; --x)
             {
               var pixel = bmp.GetPixel(x,line);
             }
           }
        }
