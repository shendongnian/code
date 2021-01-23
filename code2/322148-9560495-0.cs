        var b = new Bitmap(Width, Height, PixelFormat.Format8bppIndexed);
        ColorPalette ncp = b.Palette;
        for (int i = 0; i < 256; i++)
            ncp.Entries[i] = Color.FromArgb(255, i, i, i);
        b.Palette = ncp;
        var BoundsRect = new Rectangle(0, 0, Width, Height);
        BitmapData bmpData = b.LockBits(BoundsRect,
                                        ImageLockMode.WriteOnly,
                                        b.PixelFormat);
        IntPtr ptr = bmpData.Scan0;
        int bytes = bmpData.Stride*b.Height;
        var rgbValues = new byte[bytes];
        // fill in rgbValues, e.g. with a for loop over an input array
        Marshal.Copy(rgbValues, 0, ptr, bytes);
        b.UnlockBits(bmpData);
        return b;
