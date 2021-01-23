    public void drawRotatedText(Bitmap bmp, int x, int y, float angle, string text, Font font, Brush brush)
    {
      Graphics g = Graphics.FromImage(bmp);
      g.TranslateTransform(x, y); // Set rotation point
      g.RotateTransform(angle); // Rotate text
      g.TranslateTransform(-x, -y); // Reset translate transform
      SizeF size = g.MeasureString(text, font); // Get size of rotated text (bounding box)
      g.DrawString(text, font, brush, new PointF(x - size.Width / 2.0f, y - size.Height / 2.0f)); // Draw string centered in x, y
      g.ResetTransform(); // Only needed if you reuse the Graphics object for multiple calls to DrawString
      g.Dispose();
    }
