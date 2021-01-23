     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Path p = new Path();
                p.Data = CreateSpiralGeometry(1000, new Point() { X = 200, Y = 180 },Math.PI*10, 100);
                p.Stroke = Brushes.Black;
                
                AddChild(p);
            }
    
            private PathGeometry CreateSpiralGeometry(int nOfSteps, Point startPoint, double tetha, double alpha)
            {
                PathFigure spiral = new PathFigure();
                spiral.StartPoint = startPoint;
                
    
                for(int i=0;i<nOfSteps;++i)
                {
                    var t = (tetha/nOfSteps)*i;
                    var a = (alpha/nOfSteps)*i;
                    Point to = new Point(){X=startPoint.X+a*Math.Cos(t), Y=startPoint.Y+a*Math.Sin(t)};
                    spiral.Segments.Add(new LineSegment(to,true));
                }
                return new PathGeometry(new PathFigure[]{ spiral});
            }
    
    
            
        }
