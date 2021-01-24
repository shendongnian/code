    static void Main(string[] args)
    {
        var imageList = Directory.GetFiles(@"C:\Users\ABC\Desktop\cars");
        Bitmap destnationBitmap = new Bitmap(1000, 300);
        Graphics g = Graphics.FromImage(destnationBitmap);
        try
        {
            var drawPoint = new Point(0, 0);
            foreach (string imagePath in imageList)
            {
                var tempBitmap = new Bitmap(imagePath);
                g.DrawImage(tempBitmap, drawPoint);
                drawPoint.X += tempBitmap.Width;
            }
        }
        finally
        {
            var tiffVersion = ConverTo(destnationBitmap, ImageFormat.Tiff);
            tiffVersion.Save("TiffVersion.tiff");
            g.Dispose();
        }
    }
    public static Image ConverTo(Bitmap bitmapImage, ImageFormat pFormat)
    {
        MemoryStream stream = new MemoryStream();
        bitmapImage.Save(stream, pFormat);
        return new Bitmap(stream);
    }
