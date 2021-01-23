    Bitmap b = new Bitmap( "some path" );
    BitmapData data = b.LockBits( new Rectangle( 0, 0, b.Width, b.Height ),
    ImageLockMode.ReadOnly, b.PixelFormat );  // make sure you check the pixel format as you will be looking directly at memory
   
    unsafe
    {         
        // example assumes 24bpp image.  You need to verify your pixel depth
        // loop by row for better data locality
        for( int y = 0; y < data.Height; ++y )
        {
            byte* pRow = (byte*)data.Scan0 + y * data.Stride;
            for( int x = 0; x < data.Width; ++x )
            {
                // windows stores images in BGR pixel order
                byte r = pRow[2];
                byte g = pRow[1];
                byte b = pRow[0];
                // next pixel in the row
                pRow += 3;
            }
        }
    }
    b.UnlockBits(data);
