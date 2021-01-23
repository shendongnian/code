    GraphPane pane = zedGraphControl1.GraphPane;
    PointPairList list = new PointPairList();
    Random rand = new Random();
    for (int i = 0; i < 50; i++)
    {
        list.Add(i, rand.Next(15));
    }
    BarItem myBar = pane.AddBar("", list, Color.Red);
    Color[] colors = { Color.Red, Color.Yellow, Color.Green };
    myBar.Bar.Fill = new Fill(colors);
    myBar.Bar.Fill.Type = FillType.GradientByY;
    myBar.Bar.Fill.RangeMin = 5;
    myBar.Bar.Fill.RangeMax = 10;
    zedGraphControl1.AxisChange();
