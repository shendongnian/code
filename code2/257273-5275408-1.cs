    unsafe
    {
        //Go to first pixel, the cast is important
        byte* p = (byte*)imageData.Scan0.ToPointer();
    
        //For each line
        for (int y = 0; y < bmp.Height; y++)
        {
             //For each pixel (bmp.Width * 3) because jpg has R, G, and B value if the bitmap has an alpha do a *4 multiplier
             for (int x = 0; x < bmp.Width * 3; x++)
             {
                    //Invert from the original image
                    *p = (byte)(255 - *p);
                    //Go to next pointer
                    p++;
              }
              //Move pointer to the right end of the line and then go down to a new line
              //Skip the unused space
              p += offset;
         }
    }
    bmp.UnlockBits(imageData);
    bmp.Save(path);
