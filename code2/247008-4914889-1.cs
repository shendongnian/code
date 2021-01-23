    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Canvas.SetLeft(ellipse, 0);
            Canvas.SetTop(ellipse, 0);
    
            ellipse.MouseDown += new MouseButtonEventHandler(ellipse_MouseDown);
            ellipse.MouseMove += new MouseEventHandler(ellipse_MouseMove);
            ellipse.MouseUp += new MouseButtonEventHandler(ellipse_MouseUp);
        }
    
        private ScaleTransform EllipseScaleTransform
        {
            get { return (ScaleTransform)((TransformGroup)ellipse.RenderTransform).Children[0]; }
        }
    
        private TranslateTransform EllipseTranslateTransform
        {
            get { return (TranslateTransform)((TransformGroup)ellipse.RenderTransform).Children[1]; }
        }
    
        void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
    
            ellipse.CaptureMouse();
            var pos = e.GetPosition(canvas);
    
            AnimateScaleTo(1.25);
        }
    
        void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed || !ellipse.IsMouseCaptured)
                return;
    
            var pos = e.GetPosition(canvas);
    
            AnimatePositionTo(pos);
        }
    
        void ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!ellipse.IsMouseCaptured)
                return;
            ellipse.ReleaseMouseCapture();
    
            AnimateScaleTo(1);
        }
    
        private void AnimateScaleTo(double scale)
        {
            var animationDuration = TimeSpan.FromSeconds(1);
            var scaleAnimate = new DoubleAnimation(scale, new Duration(animationDuration));
            EllipseScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimate);
            EllipseScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimate);
        }
    
        private void AnimatePositionTo(Point pos)
        {
            var xOffset = pos.X - ellipse.Width * 0.5;
            var yOffset = pos.Y - ellipse.Height * 0.5;
    
            var animationDuration = TimeSpan.FromSeconds(1);
    
            EllipseTranslateTransform.BeginAnimation(TranslateTransform.XProperty,
                new DoubleAnimation(xOffset, new Duration(animationDuration)));
    
            EllipseTranslateTransform.BeginAnimation(TranslateTransform.YProperty,
                new DoubleAnimation(yOffset, new Duration(animationDuration)));
        }
    }
