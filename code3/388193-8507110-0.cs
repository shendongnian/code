    public class MySpecialClass {
        public Point MyPoint
        {
            get { return (Point)GetValue(MyPointProperty); }
            set { SetValue(MyPointProperty, value); }
        }
    
        public static readonly DependencyProperty MyPointProperty =
            DependencyProperty.Register("MyPoint", typeof(Point), typeof(MySpecialClass), new UIPropertyMetadata(0));
    }
