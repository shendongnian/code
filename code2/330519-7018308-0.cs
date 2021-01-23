    public class MyGradientControl : Control
    {
        public static readonly DependencyProperty StartPointDProperty =
            DependencyProperty.Register("StartPointD", typeof (Point), 
            typeof (MyGradientControl), new PropertyMetadata(new Point(0.5, 0.5)));
        static MyGradientControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (MyGradientControl), 
                new FrameworkPropertyMetadata(typeof (MyGradientControl)));
        }
        public Point StartPointD
        {
            get { return (Point) GetValue(StartPointDProperty); }
            set { SetValue(StartPointDProperty, value); }
        }
    }
