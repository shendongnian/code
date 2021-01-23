    var fontFamily = new FontFamily("Times New Roman");
    var font = new Font(fontFamily, 32, FontStyle.Regular, GraphicsUnit.Pixel);
    var solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
    e.Graphics.DrawString("Your Text Here", font, solidBrush, new PointF(10, 60));
