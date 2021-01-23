    var c = Chart1;
    c.ChartAreas.Add(new ChartArea());
    c.Width = 200;
    c.Height = 200;
    Series mySeries = new Series();
    mySeries.Points.DataBindXY(new string[] { "one", "two", "three" }, new int[] { 1, 2, 3 });
    //mySeries.LabelAngle = -45; // why doesn't this work?
    c.Series.Add(mySeries);
    c.ChartAreas[0].AxisX.LabelStyle.Angle = 45; // this works
