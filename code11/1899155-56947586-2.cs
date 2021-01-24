    Bitmap GetClone(string imageName)
    {
        if (!File.Exists(imageName)) return null;
        Bitmap bmp2 = null;
        using (Bitmap bmp = (Bitmap)Bitmap.FromFile(imageName))
        {
            bmp2 = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);
            bmp2.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
            using (Graphics g = Graphics.FromImage(bmp2))
            {
                g.DrawImage(bmp, 0, 0);
            }
        }
        return bmp2;
    }
