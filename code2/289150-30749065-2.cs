    public class Cls_Barriere
    {
        
        // animazione periferica
        public static void LineAnimation(Line _line,String _colore)
        {
            Storyboard result = new Storyboard();
            Duration duration = new Duration(TimeSpan.FromSeconds(2));
            ColorAnimation animation = new ColorAnimation();
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.Duration = duration;
            switch (_colore.ToUpper())
            {
                case "RED": 
                    animation.From = Colors.Red;
                    break;
                case "ORANGE": 
                    animation.From = Colors.Orange;
                    break;
                case "YELLOW": 
                    animation.From = Colors.Yellow;
                    break;
                case "GRAY": 
                    animation.From = Colors.DarkGray;
                    break;
                default: 
                    animation.From = Colors.Green;
                    break;
            }
            animation.To = Colors.Gray;
            Storyboard.SetTarget(animation, _line);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Line.Stroke).(SolidColorBrush.Color)"));
            result.Children.Add(animation);
            result.Begin();
        }
    }
    //***************************************************************************  
    public partial class MainPage : UserControl
    {
        public Line _line;
        
        public MainPage()
        {
            InitializeComponent();
            Canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
            Canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp;
        }
        void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _line.X2 = e.GetPosition(this.Canvas).X;
            _line.Y2 = e.GetPosition(this.Canvas).Y;
            _line.Loaded += _line_Loaded;
            Canvas.Children.Add(_line);
        }
        void _line_Loaded(object sender, RoutedEventArgs e)
        {
            Cls_Barriere.LineAnimation(sender as Line, "RED");
        }
        void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _line = new Line();
            _line.Stroke = new SolidColorBrush(Colors.White);
            _line.StrokeThickness = 5;
            _line.StrokeStartLineCap = PenLineCap.Round; 
            _line.StrokeEndLineCap = PenLineCap.Round;
            _line.StrokeDashCap = PenLineCap.Round;
            
            _line.X1 = e.GetPosition(this.Canvas).X;
            _line.Y1= e.GetPosition(this.Canvas).Y;
            
        }
