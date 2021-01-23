    using (Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width,
                                   pictureBox1.ClientSize.Height)) {
      using (Graphics g = Graphics.FromImage(bmp)) {
        g.DrawImage(yourBitmap,
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    new Rectangle(0, 0, yourImage.Width, yourImage.Height),
                    GraphicsUnit.Pixel);
      }
      bmp.Save(@"c:\yourfile.png", ImageFormat.Png);
    }
