    void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        var pos = e.Location;
        var results = chart1.HitTest(pos.X, pos.Y,false, ChartElementType.DataPoint);
        foreach (var result in results)
        {
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // use result.Series etc...
            }
        }
    }
