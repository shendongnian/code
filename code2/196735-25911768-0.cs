    public sealed class ArcPolygon : Shape
        {
            public bool RefreshOnPointAdd { get; set; }
            
            private readonly Geometry _geometry;
            private readonly PathFigure _figure;
    
            public ArcPolygon()
            {
                RefreshOnPointAdd = true;
    
                _geometry = new PathGeometry();
                _figure = new PathFigure();
    
                ((PathGeometry)_geometry).Figures.Add(_figure);
    
                _pointCollection = new ArcPointCollection();
                _pointCollection.CollectionChanged += PointCollectionChanged;
            }
    
            public static readonly DependencyProperty FillRuleProperty = DependencyProperty.Register("FillRule", typeof(FillRule), typeof(ArcPolygon), new FrameworkPropertyMetadata(FillRule.EvenOdd, FrameworkPropertyMetadataOptions.AffectsRender));
            public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double?), typeof(ArcPolygon), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    
            public void Refresh()
            {
                DefineGeometry();
            }
    
            private void DefineGeometry()
            {
                var points = PointCollection;
    
                _figure.Segments.Clear();
    
                if(points.Any())
                {
                    // start point
                    _figure.StartPoint = points[0];
    
                    if(points.Count > 1)
                    {
                        // points between
                        for(int i = 1; i < (points.Count - 1); i++)
                        {
                            // adjust radius if points are too close
                            var v1 = (Point)points[i] - points[i - 1];
                            var v2 = (Point)points[i + 1] - points[i];
    
                            var radius = (points[i].Radius ?? Radius) ?? 0;
    
                            radius = Math.Min(Math.Min(v1.Length, v2.Length) / 2, radius);
    
                            // draw the line, and stop before the next point
                            double len = v1.Length;
                            v1.Normalize();
                            v1 *= (len - radius);
                            var line = new LineSegment((Point)points[i - 1] + v1, true);
                            _figure.Segments.Add(line);
    
                            // draw the arc to the next point
                            v2.Normalize();
                            v2 *= radius;
                            var direction = (Vector.AngleBetween(v1, v2) > 0) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
                            var arc = new ArcSegment((Point)points[i] + v2, new Size(radius, radius), 0, false, direction, true);
                            _figure.Segments.Add(arc);
                        }
    
                        // last point
                        _figure.Segments.Add(new LineSegment(points[points.Count - 1], true));
                    }
                }
            }
    
            protected override Size MeasureOverride(Size constraint)
            {
                DefineGeometry();
                return base.MeasureOverride(constraint);
            }
    
            protected override Geometry DefiningGeometry
            {
                get
                {
                    return _geometry;
                }
            }
    
            public double? Radius
            {
                get
                {
                    return (double?)GetValue(RadiusProperty);
                }
                set
                {
                    SetValue(RadiusProperty, value);
                }
            }
    
            public FillRule FillRule
            {
                get
                {
                    return (FillRule)GetValue(FillRuleProperty);
                }
                set
                {
                    SetValue(FillRuleProperty, value);
                    ((PathGeometry)_geometry).FillRule = value;
                }
            }
    
            private ArcPointCollection _pointCollection;
            /// <summary>
            /// Gets or sets a collection that contains the points of the polygon.
            /// </summary>
            public ArcPointCollection PointCollection
            {
                get { return _pointCollection; }
                set
                {
                    _pointCollection = value;
                    if(RefreshOnPointAdd) Refresh();
                }
            }
    
            // <summary>
            // Gets or sets the control's text
            // </summary>
            public string Points
            {
                get
                {
                    return string.Join(" ", PointCollection.Select(x => x.ToString()));
                }
    
                set
                {
                    var pointCollection = new ArcPointCollection();
    
                    //10,50,45 180,50 180,150,45 10,150
                    var points = value.Split(' ');
                    foreach(var point in points)
                    {
                        if(point.Trim() == string.Empty) continue;
    
                        var xyarc = point.Split(',');
                        var item = new ArcPoint();
                        if(xyarc.Length >= 1) item.X = double.Parse(xyarc[0], CultureInfo.InvariantCulture);
                        if(xyarc.Length >= 2) item.Y = double.Parse(xyarc[1], CultureInfo.InvariantCulture);
                        if(xyarc.Length >= 3) item.Radius = double.Parse(xyarc[2], CultureInfo.InvariantCulture);
    
                        pointCollection.Add(item);
                    }
    
                    PointCollection = pointCollection;
                }
            }
    
            private void PointCollectionChanged(object sender, EventArgs e)
            {
                if(RefreshOnPointAdd) Refresh();
            }
    
            public void Reset()
            {
                _pointCollection.Clear();
            }
    
            public void AddPoint(double x, double y)
            {
                _pointCollection.Add(x, y);
            }
    
            public void AddPoint(double x, double y, double? radius)
            {
                _pointCollection.Add(x, y, radius);
            }
        }
    
        public sealed class ArcPoint
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double? Radius { get; set; }
    
            public ArcPoint()
            {
            }
    
            public ArcPoint(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
    
            public ArcPoint(double x, double y, double? radius)
            {
                this.X = x;
                this.Y = y;
                this.Radius = radius;
            }
    
            public static implicit operator Point(ArcPoint point)
            {
                return new Point(point.X, point.Y);
            }
            public static implicit operator ArcPoint(Point point)
            {
                return new ArcPoint(point.X, point.Y);
            }
    
            public override string ToString()
            {
                if(Radius == null)
                    return string.Format(CultureInfo.InvariantCulture, "{0},{1}", X, Y);
                return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", X, Y, Radius);
            }
        }
    
        public sealed class ArcPointCollection : ObservableCollection<ArcPoint>
        {
            public void Add(double x, double y)
            {
                Add(new ArcPoint(x, y));
            }
    
            public void Add(double x, double y, double? radius)
            {
                Add(new ArcPoint(x, y, radius));
            }
        }
