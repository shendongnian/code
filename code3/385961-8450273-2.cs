    Point deltaStart;
    Point deltaEnd;
    bool dragging = false;
            
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
    
        if (e.Button == System.Windows.Forms.MouseButtons.Left && m.IsPointOnLine(e.Location, 5))
        {
            dragging = true;
            deltaStart = new Point(m.Start.X - e.Location.X, m.Start.Y - e.Location.Y);
            deltaEnd = new Point(m.End.X - e.Location.X, m.End.Y - e.Location.Y);
        }
    }
    
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (dragging && deltaStart != null && deltaEnd != null )
        {
            m.Start = new Point(deltaStart.X + e.Location.X, deltaStart.Y + e.Location.Y);
            m.End = new Point(deltaEnd.X + e.Location.X, deltaEnd.Y + e.Location.Y);
            this.Refresh();
        }
    }
    
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        dragging = false;
    }
