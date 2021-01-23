    GraphicsPath path = new GraphicsPath();
    path.AddString("cool", new FontFamily("Times New Roman"), 0, 300, new PointF(), StringFormat.GenericDefault);
    e.Graphics.DrawPath(new Pen(Color.Black, 1), path); 
    path = path.Shrink(3);
    e.Graphics.DrawPath(new Pen(Color.Red), path);
