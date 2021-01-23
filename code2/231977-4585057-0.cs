    Bitmap bmp = new Bitmap(50,50);
    Graphics g = Graphics.FromImage(bmp);
    g.FillRectangle(Brushes.Green, 0, 0, 50, 50);
    g.Dispose();
    bmp.Save("filepath", System.Drawing.Imaging.ImageFormat.Png);
    bmp.Dispose();
