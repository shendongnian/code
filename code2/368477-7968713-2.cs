    Bitmap bmp = new Bitmap(pictureBox1.Image);
    using (Graphics g = Graphics.FromImage(bmp)) {
      g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
      g.RotateTransform(30);
      SizeF textSize = g.MeasureString("hi", font);
      g.DrawString("hi", font, Brushes.Red, -(textSize.Width / 2), -(textSize.Height / 2));
    }
