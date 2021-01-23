    private void g_Layout(object sender, System.LayoutEventArgs e)
    {
        b1.Size = b2.Size = new Size(g.DisplayRectangle.Width, 
                                     g.DisplayRectangle.Height/2 - 1);
        b1.Location = new Point(g.DisplayRectangle.Left, 
                                g.DisplayRectangle.Top);
        b2.Location = new Point(g.DisplayRectangle.Left, 
                               g.DisplayRectangle.Top + g.DisplayRectangle.Height/2);
    }
