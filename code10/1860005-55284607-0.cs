    private void timer1_Tick(object sender, EventArgs e)
    {
        if (Control.MouseButtons.HasFlag(MouseButtons.Left))
        {
            using (Graphics g = treeView1.CreateGraphics())
            {
                treeView1.Refresh();
                var hitt = treeView1.HitTest(treeView1.PointToClient(Control.MousePosition));
                var n = hitt.Node;
                if (n != null)
                {
                    int y = n.Bounds.Y;  // draw above the node; maybe change to n.Bound.Bottom ?
                    Size sz = treeView1.ClientSize;
                    g.DrawLine(Pens.Orange, 0, y, sz.Width, y);
                }
            }
        }
    }
