    public MainWindow()
            {
                InitializeComponent();
                canvas.Children.Clear();
                Point[] points = new Point[2]
                {
                new Point(0,  100),
                new Point(300 , 100)
                };
                DrawLine(points);
              
            }
    private void DrawLine(Point[] points)
            {
                Polyline line = new Polyline();
                PointCollection collection = new PointCollection();
                foreach (Point p in points)
                {
                    collection.Add(p);
                }
                line.Points = collection;
                line.Stroke = new SolidColorBrush(Colors.Red);
                line.StrokeThickness = 1;
                canvas.Children.Add(line);
            }
