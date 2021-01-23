        GraphicsPath gp = new GraphicsPath();
        gp.AddLine(new Point(10, 10), new Point(75, 10));
        gp.AddArc(50, 10, 50, 50, 270, 90);
        gp.AddLine(new Point(100, 35), new Point(100, 100));
        gp.AddArc(80, 90, 20, 20, 0, 90);
        gp.AddLine(new Point(90, 110), new Point(10, 110));
        gp.AddLine(new Point(10, 110), new Point(10, 10));
        Bitmap bm = new Bitmap(110, 120);
        LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(100, 110), Color.Red, Color.Yellow);
        using (Graphics g = Graphics.FromImage(bm))
        {
            g.FillPath(brush, gp);
            g.DrawPath(new Pen(Color.Black, 1), gp);
            g.Save();
        }
        bm.Save(@"c:\bitmap.bmp");
