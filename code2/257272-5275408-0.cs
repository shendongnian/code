    unsafe
    {
        //Go to first pixel, the Cast is importnat
        byte* p = (byte*)imageData.Scan0.ToPointer();
    
        //For each line
        for (int y = 0; y < bmp.Height; y++)
        {
             //For Each Pixel (bmp.Width * 3) because jpg has R, G, and B value if the bitmap has aplha do the *4 multiplier
             for (int x = 0; x < bmp.Width * 3; x++)
             {
                    //Make invert from original image
                    *p = (byte)(255 - *p);
                    //Go to next pointer
                    p++;
              }
              //move pointer right most line to next down first line
              //skip the unused space
              p += offset;
         }
    }
    bmp.UnlockBits(imageData);
    bmp.Save(path);
