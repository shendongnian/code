    for (int n = 0; n < this.NumberOfRevisions; n++)
    {
        CombinedGeometry geometry = new CombinedGeometry() { GeometryCombineMode = GeometryCombineMode.Union };
        PointCollection points = new PointCollection();
        for (int i = 0; i < this.NumberOfMetrics; i++)
        {
            points.Add(new Point(MAX_VALUE - this.Metrics[n, i] * Math.Cos(DegreeToRadian(i * (360 / (this.NumberOfMetrics)))), MAX_Y_GUI - this.Metrics[n, i] * Math.Sin(DegreeToRadian(i * (360 / (this.NumberOfMetrics))))));
        }
        Polygon poly = new Polygon();
        poly.Points = points;
        geometry.Geometry1 = poly.RenderedGeometry;
        geometry.Geometry2 = poly.RenderedGeometry;
        polygons.Add(poly);
        paths.Add(path = new Path() { Data = geometry, Fill = Brushes.Red, Stroke = Brushes.Transparent });
    }
