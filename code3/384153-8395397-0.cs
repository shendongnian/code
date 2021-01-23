    // create a pen with a width of 2px (half of it will be blanked out so it will
    // essentially be a width of 1px)
    Pen pen = new Pen(Color.Blue, 2f);
    // build a GraphicsPath with the rectangles
    GraphicsPath gp = new GraphicsPath();
    gp.AddRectangle(...);
    gp.AddRectangle(...);
    gp.AddRectangle(...);
    // g is our Graphics object
    // exclude the region so the path doesn't draw over it
    Region reg = new Region(gp);
    g.ExcludeClip(reg);
    // now draw path, it won't show up inside the excluded clipping region
    g.DrawPath(pen, gp);
    // clean up
    g.ResetClip();
    pen.Dispose();
    gp.Dispose();
    reg.Dispose();
