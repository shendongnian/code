    void fun()
    {
        int width = 220, height = 115;
        int xPosition=5,yPosition=5;
        Image m = new Bitmap(width,height);
        Graphics gx = Graphics.FromImage(m);
        gx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        gx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        gx.DrawString("Hello Wrold", new System.Drawing.Font("tahoma", 12.0f), Brushes.Black, xPosition, yPosition);
        m.Save(@"d:\myimage.png",ImageFormat.Png);
    }
