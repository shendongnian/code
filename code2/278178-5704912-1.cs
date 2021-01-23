        private void Chart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var chart = sender as Chart;
            //In my example the line series is the first item of the chart series
            var line = (LineSeries)chart.Series[0];
            //Find the nearest point on the LineSeries
            var newPoint = e.GetPosition(line);
            var selectIndex = this.FindNearestPointIndex(line.Points, newPoint);
            if (selectIndex != null)
            {
                //Select a real item from the items source
                var source = line.ItemsSource as IList;
                line.SelectedItem = source[selectIndex.Value];
            }
        }
        private int? FindNearestPointIndex(PointCollection points, Point newPoint)
        {
            if (points == null || !points.Any())
                return null;
            //c^2 = a^2+b^2
            Func<Point, Point, double> getLength = (p1, p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            
            //Create the collection of points with more information
            var items = points.Select((p,i) => new { Point = p, Length = getLength(p, newPoint), Index = i });
            var minLength = items.Min(item => item.Length);
            //Uncomment if it is necessary to have some kind of sensitive area
            //if (minLength > 50)
            //    return null;
            //The index of the point with min distance to the new point
            return items.First(item => item.Length == minLength).Index;
        }
