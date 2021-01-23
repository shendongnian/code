    StringFormat format = new StringFormat();
    Pen blackPen = new Pen(Color.Black); 
    GraphicsPath p = new GraphicsPath(); 
    p.AddString("My Text String", FontFamily.GenericSansSerif, 0, 72, new Point(0, 0), format); 
    e.Graphics.DrawPath(blackPen, p); //e = in this code I was printing so E is an object of type System.Drawing.Printing.PrintPageEventArgs
    //use graphics.fillPen here if you want it filled in with a color
