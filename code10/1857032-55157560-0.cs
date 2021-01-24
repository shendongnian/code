        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                overlay.MouseMove += OnOverlayMouseMove;
            }
    
            private void OnOverlayMouseMove(object sender, MouseEventArgs args)
            {
                overlay.Children.Clear();
    
                Point ps = args.GetPosition(overlay);
    
                Rectangle rect = new Rectangle
                {
                    Fill = brush,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 2,
                    Width = 100,
                    Height = 50
                };
    
                rect.Opacity = 0.5;
                rect.MouseLeftButtonDown += OnRectLeftMouseButtonDown;
                rect.Name = "Blue";
    
                Canvas.SetLeft(rect, ps.X - 50);
                Canvas.SetTop(rect, ps.Y - 25);
                overlay.Children.Add(rect);
            }
            private SolidColorBrush brush = Brushes.LightBlue;
            private void OnRectLeftMouseButtonDown(object sender, MouseEventArgs args)
            {
                Rectangle rect = sender as Rectangle;
    
                if (brush == Brushes.LightBlue)
                {
                    brush = Brushes.Black;
                }
                else
                {
                    brush = Brushes.LightBlue;
                }
    
                args.Handled = true;
            }
        }
