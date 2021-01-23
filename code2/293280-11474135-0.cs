    private void MyDrawing()
    {
        Graphics g = Graphics.FromImage(tempDraw);
        // if above line doesn't work you can use the following commented line
        //Graphics g = Graphics.Panel1.CreateGraphics();
    
        Pen myPen = new Pen(foreColor, lineWidth);
        g.DrawLine(myPen, x1, y1, x2, y2);
        myPen.Width = 100;
        myPen.Dispose();
        Panel1.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
        g.Dispose();
     }
