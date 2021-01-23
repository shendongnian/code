    private void button1_Click(object sender, EventArgs e)
    {
      using (var p = new Pen(Color.FromArgb(190, Color.Green), 5))
      {
        p.StartCap = LineCap.Round;
        p.EndCap = LineCap.ArrowAnchor;
        p.CustomEndCap = new AdjustableArrowCap(3, 3);
        p.DashStyle = DashStyle.Solid;
        var graph = this.CreateGraphics();
        graph.DrawDashedLine(p, 20, 10, new PointF(20, 20), new PointF(500, 500));
      } 
    }
