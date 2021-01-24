    List<MyPixel> pixels = new List<MyPixel>();
    using (Bitmap img = new Bitmap("t.bmp"))
    {
        var bmpData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb);
        IntPtr ptr = bmpData.Scan0;
        int bytes = Math.Abs(bmpData.Stride) * bmpData.Height;
        byte[] rgbValues = new byte[bytes];
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
        img.UnlockBits(bmpData);
    
        for (int i = 0; i < rgbValues.Length; i += 3)
        {
            var m = new MyPixel();
            int x = i / Math.Abs(bmpData.Stride);
            int y = (i - x * Math.Abs(bmpData.Stride)) / 3;
    
            m.Coord = new Point(x, y);
            m.Rgb = Color.FromArgb(rgbValues[i + 2], rgbValues[i + 1], rgbValues[i]);
            pixels.Add(m);
        }
    
        var maxred = pixels.OrderByDescending(x => x.Rfraction).Take(10);
        var maxblue = pixels.OrderByDescending(x => x.Bfraction).Take(10);
    }
