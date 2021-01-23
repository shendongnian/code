    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace MyControls
    {
        public sealed class RoundPolyline : Shape
        {
            public static readonly DependencyProperty FillRuleProperty = DependencyProperty.Register("FillRule", typeof(FillRule), typeof(RoundPolyline), new FrameworkPropertyMetadata(FillRule.EvenOdd, FrameworkPropertyMetadataOptions.AffectsRender));
            public static readonly DependencyProperty PointsProperty = DependencyProperty.Register("Points", typeof(PointCollection), typeof(RoundPolyline), new FrameworkPropertyMetadata(GetEmptyPointCollection(), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
            public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(RoundPolyline), new FrameworkPropertyMetadata(6.0, FrameworkPropertyMetadataOptions.AffectsRender));
    
            private Geometry _geometry;
            private void DefineGeometry()
            {
                PointCollection points = Points;
                if (points == null)
                {
                    _geometry = Geometry.Empty;
                    return;
                }
    
                PathFigure figure = new PathFigure();
                if (points.Count > 0)
                {
                    // start point
                    figure.StartPoint = points[0];
    
                    if (points.Count > 1)
                    {
                        // points between
                        double radius = Radius;
                        Size radiusSize = new Size(radius, radius);
                        for (int i = 1; i < (points.Count - 1); i++)
                        {
                            // draw the line, and stop before the next point
                            Vector v1 = points[i] - points[i - 1];
                            double len = v1.Length;
                            v1.Normalize();
                            v1 *= (len - radius);
                            Point beginPoint = points[i - 1] + v1;
                            LineSegment line = new LineSegment(beginPoint, true);
                            figure.Segments.Add(line);
    
                            // draw the arc to the next point
                            Vector v2 = points[i + 1] - points[i];
                            v2.Normalize();
                            v2 *= radius;
                            Point endPoint = points[i] + v2;
                            SweepDirection direction = (Vector.AngleBetween(v1, v2) > 0) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
                            ArcSegment arc = new ArcSegment(endPoint, radiusSize, 0, false, direction, true);
                            figure.Segments.Add(arc);
                        }
    
                        // last point
                        figure.Segments.Add(new LineSegment(points[points.Count - 1], true));
                    }
                }
                PathGeometry geometry = new PathGeometry();
                geometry.Figures.Add(figure);
                geometry.FillRule = FillRule;
                if (geometry.Bounds == Rect.Empty)
                {
                    _geometry = Geometry.Empty;
                }
                else
                {
                    _geometry = geometry;
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
    
            public double Radius
            {
                get
                {
                    return (double)GetValue(RadiusProperty);
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
                }
            }
    
            public PointCollection Points
            {
                get
                {
                    return (PointCollection)GetValue(PointsProperty);
                }
                set
                {
                    SetValue(PointsProperty, value);
                }
            }
    
            // NOTE: major hack because none of this is public, and this is very unfortunate, it should be...
            private static PointCollection _emptyPointCollection;
            private static ConstructorInfo _freezableDefaultValueFactoryCtor;
            private static object GetEmptyPointCollection()
            {
                if (_freezableDefaultValueFactoryCtor == null)
                {
                    _emptyPointCollection = (PointCollection)typeof(PointCollection).GetProperty("Empty", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null);
                    Type freezableDefaultValueFactoryType = typeof(DependencyObject).Assembly.GetType("MS.Internal.FreezableDefaultValueFactory");
                    _freezableDefaultValueFactoryCtor = freezableDefaultValueFactoryType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
                }
                return _freezableDefaultValueFactoryCtor.Invoke(new object[] { _emptyPointCollection });
            }
        }     
    }
