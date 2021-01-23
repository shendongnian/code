    Point selPoint;
    Rectangle mRect;
    void OnMouseDown(object sender, MouseEventArgs e)
    {
         selPoint = e.Location; 
        // add it to AutoScrollPosition if your control is scrollable
    }
    void OnMouseMove(object sender, MouseEventArgs e)
    {
         if (e.Button == MouseButtons.Left)
         {
            Point p = e.Location;
            int x = Math.Min(selPoint.X, p.X)
            int y = Math.Min(selPoint.Y, p.Y)
            int w = Math.Abs(p.X - selPoint.X);
            int h = Math.Abs(p.Y - selPoint.Y);
            mRect = new Rectangle(x, y, w, h);   
            this.Invalidate(); 
         }
    }
    void OnPaint(object sender, PaintEventArgs e)
    {
         e.Graphics.DrawRectangle(Pens.Blue, mRect);
    }
