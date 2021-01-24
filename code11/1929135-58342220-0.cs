        private void PlotGraph()
        {
            var points = new List<Point>() { new Point(0, 2.3), new Point(1, 2.0),
                                             new Point(2, 3.1), new Point(3, 1.3),
                                             new Point(4, 0.5), new Point(5, 3.8),
                                             new Point(6, 7.3), new Point(7, 2.4),
                                             new Point(8, 1.2), new Point(9, 0.1)};
            var range1 = new double[] { 1d, 3d };
            var otherpoints = CurvesMath.GetInterpolatedCubicSplinedCurve(points);
            var pointscurve = otherpoints.Select(p => p.Y).ToArray();
            SeriesCollection = new SeriesCollection();
            var lineSeries1 = new LineSeries
            {
                Title = "S1",
                Values = new ChartValues<double>(pointscurve),
                DataLabels = false,
                Stroke = Brushes.Transparent,
                Fill = Brushes.Transparent,
                ScalesYAt = 0,
                PointGeometrySize = 2,
                Configuration = Mappers.Xy<double>()
                                       .X((value, index) => index)
                                       .Y((value, index) => value)
                                       .Stroke((value, index) => value <= range1[0] || value >= range1[1] ? Brushes.Red : Brushes.Blue)
                                       .Fill((value, index) => value <= range1[0] || value >= range1[1] ? Brushes.Red : Brushes.Blue)
        };
            points = new List<Point>() { new Point(0, 32.5), new Point(1, 34.5),
                                         new Point(2, 29.5), new Point(3, 26.0),
                                         new Point(4, 25.8), new Point(5, 30.5),
                                         new Point(6, 32.1), new Point(7, 36.5),
                                         new Point(8, 32.4), new Point(9, 24.5)};
            var range2 = new double[] { 28d, 32d };
            otherpoints = CurvesMath.GetInterpolatedCubicSplinedCurve(points);
            pointscurve = otherpoints.Select(p => p.Y).ToArray();
            var lineSeries2 = new LineSeries
            {
                Title = "S2",
                Values = new ChartValues<double>(pointscurve),
                DataLabels = false,
                Stroke = Brushes.Transparent,
                Fill = Brushes.Transparent,
                ScalesYAt = 1,
                PointGeometrySize = 2,
                Configuration = Mappers.Xy<double>()
                                       .X((value, index) => index)
                                       .Y((value, index) => value)
                                       .Stroke((value, index) => value <= range2[0] || value >= range2[1] ? Brushes.Red : Brushes.Green)
                                       .Fill((value, index) => value <= range2[0] || value >= range2[1] ? Brushes.Red : Brushes.Green)
            };
            SeriesCollection.Add(lineSeries1);
            SeriesCollection.Add(lineSeries2);
            MyChart.AxisY.Add(new Axis());
            MyChart.AxisY.Add(new Axis());
            DataContext = this;
        }
