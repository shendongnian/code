    Bitmap bmp = ...
    byte minHue = 0;
    byte maxHue = 10;
    byte newHue = 128;
...
    BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
        ImageLockMode.ReadWrite, bmp.PixelFormat);
    IntPtr ptr = bmpData.Scan0;
    int bytes = bmpData.Stride * bmpData.Height;
    byte[] rgbValues = new byte[bytes];
    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
    for (int c = 0; c < rgbValues.Length; c += 4)
    {
        HSBColor hsb = new HSBColor(Color.FromArgb(
            rgbValues[c + 3], rgbValues[c + 2],
            rgbValues[c + 1], rgbValues[c]));
	if(hsb.H > minHue && hsb.H < maxHue)
        {
            hsb.H = Convert.ToByte(newHue);
        }
        Color color = hsb.ToRGB();
        rgbValues[c] = color.B;
        rgbValues[c + 1] = color.G;
        rgbValues[c + 2] = color.R;
        rgbValues[c + 3] = color.A;
    }
    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
    bmp.UnlockBits(bmpData);
