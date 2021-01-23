    Point endPoint;
    
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    
        using (var p = new Pen(Color.Black, 3))
        {
            p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
    
            g.DrawLine(p, st, endPoint);
        }
    
        Thread.Sleep(30);
    }
    
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        endPoint = e.Location;
        panel1.Invalidate();
    }
     
