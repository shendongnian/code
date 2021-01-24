    public partial class MainWindow : Window
    {
        private Color normal = Color.FromRgb(255, 0, 0);
        private Color active = Color.FromRgb(0, 0, 0);
        private SolidColorBrush rectangleBrush;
        public MainWindow()
        {
            InitializeComponent();
            rectangleBrush = new SolidColorBrush(normal);
            overlay.MouseMove += OnOverlayMouseMove;
        }
        private void OnOverlayMouseMove(object sender, MouseEventArgs args)
        {
            overlay.Children.Clear();
            Point ps = args.GetPosition(overlay);
            Rectangle rect = new Rectangle
            {
                Fill = rectangleBrush,
                Stroke = Brushes.LightGray,
                StrokeThickness = 2,
                Width = 100,
                Height = 50
            };
            rect.Opacity = 0.5;
            rect.MouseLeftButtonDown += OnRectLeftMouseButtonDown;
            Canvas.SetLeft(rect, ps.X - 50);
            Canvas.SetTop(rect, ps.Y - 25);
            overlay.Children.Add(rect);
        }
        private void OnRectLeftMouseButtonDown(object sender, MouseEventArgs args)
        {
            Rectangle rect = sender as Rectangle;
            if ((rect.Fill as SolidColorBrush).Color == normal) {
                rectangleBrush.Color = active;
            } else {
                rectangleBrush.Color = normal;
            }
            args.Handled = true;
        }
    }
