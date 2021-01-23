    Font MyFont = new Font(FontFamily, Font,FontStyle.Bold, GraphicsUnit.Point);
    MyGraphics = Graphics.FromImage(bmpImage);
    MyGraphics.Clear(Color.FromName("Red"));
    MyGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
    MyGraphics.DrawString("Hello dalvir", MyFont,
                        new SolidBrush(Color.FromName("Red")), 0, 0);
    MyGraphics.Flush();
