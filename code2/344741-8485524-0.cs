    //using System.Drawing.Drawing2D;
    
    g.FillRectangle(Brushes.White,x,y,width,height);
    g.CompositingMode = CompositingMode.SourceCopy;    
    g.FillRectangle(Brushes.Transparent,x,y,width,height);
