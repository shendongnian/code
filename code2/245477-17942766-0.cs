    var zed = new ZedGraph.ZedGraphControl { Dock = System.Windows.Forms.DockStyle.Fill };
    
    var poly = new ZedGraph.PolyObj
    {
        Points = new[]
        {
            new ZedGraph.PointD(0, 0),
            new ZedGraph.PointD(0.5, 1),
            new ZedGraph.PointD(1, 0.5),
            new ZedGraph.PointD(0, 0)
        },
        Fill = new ZedGraph.Fill(Color.Blue),
        ZOrder = ZedGraph.ZOrder.E_BehindCurves
    };
    
    var poly1 = new ZedGraph.PolyObj
    {
        Points = new[]
        {
            new ZedGraph.PointD(1, 0),
            new ZedGraph.PointD(0.25, 1),
            new ZedGraph.PointD(0.5, 0),
            new ZedGraph.PointD(1, 0)
        },
        Fill = new ZedGraph.Fill(Color.Red),
        ZOrder = ZedGraph.ZOrder.E_BehindCurves
    };
    
    zed.GraphPane.AddCurve("Line", new[] { 0.0, 1.0 }, new[] { 0.0, 1.0 }, Color.Green);
    zed.GraphPane.GraphObjList.Add(poly1);
    zed.GraphPane.GraphObjList.Add(poly);
