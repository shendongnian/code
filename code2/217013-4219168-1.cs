    private void button2_Click(object sender, EventArgs e)
    {
        using (var p = new Pen(Color.FromArgb(190, Color.Green), 5))
        {
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.ArrowAnchor;
            p.CustomEndCap = new AdjustableArrowCap(3, 3);
            p.DashStyle = DashStyle.Dash;
            p.DashCap = DashCap.Triangle;
            var graph = this.CreateGraphics();
            graph.DrawLine(p, new Point(20, 20), new Point(150, 150));
        }
    }
