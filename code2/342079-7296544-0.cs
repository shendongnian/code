     BitMap image= new BitMap(path);
     
     // Do some processing
     for(x=0; x<image1.Width; x++)
     {
         for(y=0; y<image.Height; y++)
         {
             Color pixelColor = image.GetPixel(x, y);
             Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
             image.SetPixel(x, y, newColor);
         }
     }
    image.Save(newPath);
