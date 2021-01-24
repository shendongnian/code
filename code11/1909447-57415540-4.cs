    void initPainting(Control parent, Control baseCtl)
    {
        foreach (Control ctl in parent.Controls)
        {
            ctl.Paint += (s, e) =>
            {
                foreach (var drawing in drawings)
                {
                    Point offset = 
                         baseCtl.PointToClient(ctl.PointToScreen(Point.Empty));
                    Graphics g = e.Graphics;
                    g.TranslateTransform(-offset.X, -offset.Y);
                    drawing.Draw(g);
                    g.ResetTransform();
                }
            };
            initPainting(ctl, baseCtl);  // recursion
        }
    }
