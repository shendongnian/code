    // assuming g is the Graphics object on which you want to draw the text
    GraphicsPath p = new GraphicsPath(); 
    p.AddString(
        "My Text String",             // text to draw
        FontFamily.GenericSansSerif,  // or any other font family
        (int) FontStyle.Regular,      // font style (bold, italic, etc.)
        g.DpiY * fontSize / 72,       // em size
        new Point(0, 0),              // location where to draw text
        new StringFormat());          // set options here (e.g. center alignment)
    g.DrawPath(Pens.Black, p);
    // + g.FillPath if you want it filled as well
