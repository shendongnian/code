    void setLVBack(ListView lv)
    {
        int alpha = 64;
        Point p1 = lv.Parent.PointToScreen(lv.Location);
        Point p2 = lv.PointToScreen(Point.Empty);
        p2.Offset(-p1.X, -p1.Y );
        if (lv.BackgroundImage != null) lv.BackgroundImage.Dispose();
        lv.Hide();
        Bitmap bmp = new Bitmap(lv.Parent.Width, lv.Parent.Height);
        lv.Parent.DrawToBitmap(bmp, lv.Parent.ClientRectangle);
        Rectangle r = lv.Bounds;
        r.Offset(p2.X, p2.Y);
        bmp = bmp.Clone(r, PixelFormat.Format32bppArgb);
        using (Graphics g = Graphics.FromImage(bmp))
        using (SolidBrush br = new SolidBrush(Color.FromArgb(alpha, lv.BackColor)))
        {
            g.FillRectangle(br, lv.ClientRectangle);
        }
        lv.BackgroundImage = bmp;
        lv.Show();
    }
