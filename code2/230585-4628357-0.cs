    protected override void OnPaint(PaintEventArgs e)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddString("cool", new FontFamily("Arial"), 0, 200, new PointF(), StringFormat.GenericDefault);
        path.AddEllipse(150, 50, 80, 80);
        path.AddEllipse(150 + 100, 50 + 100, 80 + 100, 80 + 100);
        GraphicsPath offset1 = Offset(path, -5);
        GraphicsPath offset2 = Offset(path, 5);
        e.Graphics.DrawPath(new Pen(Color.Black, 1), path);
        e.Graphics.DrawPath(new Pen(Color.Red, 1), offset1);
        e.Graphics.DrawPath(new Pen(Color.Blue, 1), offset2);
    }
