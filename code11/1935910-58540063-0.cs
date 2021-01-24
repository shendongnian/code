    public void DrawCircle(Chart Graph, double centerX, double centerY, double radius, int amountOfEdges)
    {
        string name = "circle_" + centerX + centerY + radius + amountOfEdges;
        // Create new data series
        if (Graph.Series.IndexOf(name) == -1)
            Graph.Series.Add(name);
        // preferences of the line
        Graph.Series[name].ChartType = SeriesChartType.Line;
        Graph.Series[name].Color = Color.FromArgb(0, 0, 0);
        Graph.Series[name].BorderWidth = 1;
        Graph.Series[name].IsVisibleInLegend = false;
        // add line segments (first one also as last one)
        for (int k = 0; k <= amountOfEdges; k++)
        {
            double x = centerX + radius * Math.Cos(k * 2 * Math.PI / amountOfEdges);
            double y = centerY + radius * Math.Sin(k * 2 * Math.PI / amountOfEdges);
            Graph.Series[name].Points.AddXY(x, y);
        }
    }
