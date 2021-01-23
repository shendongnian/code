    var myPath = new Path
    {
        Stroke = Brushes.Black,
        StrokeThickness = 1.0,
        Data = new PathGeometry
        {
            Figures = new PathFigureCollection
            {
                new PathFigure
                {
                    StartPoint = new Point(10, 100),
                    Segments = new PathSegmentCollection
                    {
                        new QuadraticBezierSegment
                        {
                            Point1 = new Point(200, 200),
                            Point2 = new Point(300, 100),
                        },
                    },
                },
            },
        },
    };
    myGrid.Children.Add(myPath);
