    Bitmap newBitmap = new Bitmap(sourceImage.Size.Width, sourceImage.Size.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    Graphics g = Graphics.FromImage(newBitmap);
    g.DrawImage(sourceImage, new Point(0, 0));
    g.Dispose();
    pictureBoxCurrency.Image = sourceImage;
