            string PathFormatter = "<PathGeometry xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"> "
                + "<PathGeometry.Figures>"
                + "<PathFigure StartPoint=\"{0},{1}\">"
                + "<PathFigure.Segments>"
                + "<PathSegmentCollection>"
                + "<BezierSegment Point1=\"{2},{3}\" Point2=\"{4},{5}\" Point3=\"{6},{7}\" />"
                + "</PathSegmentCollection>"
                + "</PathFigure.Segments>"
                + "</PathFigure>"
                + "</PathGeometry.Figures>"
                + "</PathGeometry>";
            double p1x = x1 * 0.67 + x2 * 0.33;
            double p1y = y1;
            double p2x = x1 * 0.33 + x2 * 0.67;
            double p2y = y2;
            string data = String.Format(PathFormatter, x1, y1, p1x, p1y, p2x, p2y, x2, y2);
            Graphic.Children.Add(new Path()
            {
                Data = (PathGeometry)XamlReader.Load(data),
                Stroke = new SolidColorBrush(color),
                StrokeThickness = 4,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                Height = 368,
                CacheMode = new BitmapCache(),
                //Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            });
