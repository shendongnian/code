    Image imgOriginal = Bitmap.FromFile(path);
    double height = (imgOriginal.Height * width) / imgOriginal.Width;
    Image imgnew = new Bitmap(width, weight, PixelFormat.Format32bppArgb);
    Graphics g = Graphics.FromImage(imgnew);
    g.DrawImage(imgOriginal, new Point[]{new Point(0,0), new Point(width, 0), new Point(0, height)}, new Rectangle(0,0,imgOriginal.Width, imgOriginal.Height), GraphicsUnit.Pixel);
