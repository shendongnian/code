    public class MouseTrackerDecorator : Decorator
    {
        static readonly DependencyProperty MousePositionProperty;
        static MouseTrackerDecorator()
        {
            MousePositionProperty = DependencyProperty.Register("MousePosition", typeof(Point), typeof(MouseTrackerDecorator));
        }
        public override UIElement Child
        {
            get
            {
                return base.Child;
            }
            set
            {
                if (base.Child != null)
                    base.Child.MouseMove -= _controlledObject_MouseMove;
                base.Child = value;
                base.Child.MouseMove += _controlledObject_MouseMove;
            }
        }
        public Point MousePosition
        {
            get
            {
                return (Point)GetValue(MouseTrackerDecorator.MousePositionProperty);
            }
            set
            {
                SetValue(MouseTrackerDecorator.MousePositionProperty, value);
            }
        }
        void _controlledObject_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(base.Child);
            // Here you can add some validation logic
            MousePosition = p;            
        }
    }
