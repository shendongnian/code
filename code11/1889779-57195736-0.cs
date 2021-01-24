    // Channels are: B=0, G=1, R=2, A=3
    Int32 channel = 1 // for this example, extract the Green channel.
    Int32 width;
    Int32 height;
    Byte[] rgbaValues;
    using (Bitmap bmp = new Bitmap(screenWidth, position))
    using (Graphics g = Graphics.FromImage(bmp))
    {
        width = bmp.Width
        height = bmp.Height;
        g.CopyFromScreen(screenLeft, screenTop, 0, 0, bmp.Size);    
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        Int32 bytes = bmpData.Stride * bmp.Height;
        rgbaValues = new byte[bytes];
        Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);
        bmp.UnlockBits(bmpData);
        g.Dispose();
    }
    Byte[] channelValues = new byte[width * height];
    Int32 lineStart = 0;
    Int32 lineStartChannel = 0;
    for (Int32 y = 0; y < height; ++y)
    {
        Int32 offset = lineStart;
        Int32 offsetChannel = lineStartChannel;
        for (Int32 x = 0; x < width; ++x)
        {
            // For reference:
            //Byte blue  = rgbaValues[offset + 0];
            //Byte green = rgbaValues[offset + 1];
            //Byte red   = rgbaValues[offset + 2];
            //Byte alpha = rgbaValues[offset + 3];
            channelValues[offsetChannel] = rgbaValues[offset + channel];
            offset += 4;
            offsetChannel++;
        }
        lineStart += stride;
        lineStartChannel += width;
    }
    File.WriteAllBytes(filename, channelValues);
