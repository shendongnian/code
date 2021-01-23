    MemoryStream ms = new MemoryStream();
    YOURBITMAP.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
    BitmapImage image = new BitmapImage();
    image.BeginInit();
    ms.Seek(0, SeekOrigin.Begin);
    image.StreamSource = ms;
    image.EndInit();
