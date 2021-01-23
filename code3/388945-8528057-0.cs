    unsafe
    {
        byte * p = (byte *)(void *)Scan0;
        int nOffset = stride - b.Width*3;
        byte red, green, blue;
        for(int y=0;y < b.Height;++y)
        {
            for(int x=0; x < b.Width; ++x )
            {
               blue = p[0];
               green = p[1];
               red = p[2];
               p[0] = p[1] = p[2] = (byte)(.299 * red 
                   + .587 * green 
                   + .114 * blue);
               p += 3;
           }
           p += nOffset;
       }
    }
