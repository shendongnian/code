      public class FrameworkElementAdorner : Adorner
      {
        private FrameworkElement _child;
    
        public FrameworkElementAdorner(UIElement adornedElement)
          : base(adornedElement)
        {
        }
    
        protected override int VisualChildrenCount
        {
          get { return 1; }
        }
    
        public FrameworkElement Child
        {
          get { return _child; }
          set
          {
            if (_child != null)
            {
              RemoveVisualChild(_child);
            }
            _child = value;
            if (_child != null)
            {
              AddVisualChild(_child);
            }
          }
        }
    
        protected override Visual GetVisualChild(int index)
        {
          if (index != 0) throw new ArgumentOutOfRangeException();
          return _child;
        }
    
        protected override Size MeasureOverride(Size constraint)
        {
          _child.Measure(constraint);
          return _child.DesiredSize;
        }
    
        protected override Size ArrangeOverride(Size finalSize)
        {
          // Adjust your offset here:
          _child.Arrange(new Rect(new Point(-20, -20), finalSize));
          return new Size(_child.ActualWidth, _child.ActualHeight);
        }
