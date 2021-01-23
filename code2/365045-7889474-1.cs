    private FrameworkElement _child;
    public FrameworkElementAdorner(UIElement adornedElement)
      : base(adornedElement)
    {
    }
    protected override int VisualChildrenCount
    {
      get
      {
        return 1;
      }
    }
    protected override Visual GetVisualChild(int index)
    {
      if (index != 0) throw new ArgumentOutOfRangeException();
      return _child;
    }
    public FrameworkElement Child
    {
      get
      {
        return _child;
      }
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
    protected override Size ArrangeOverride(Size finalSize)
    {
      _child.Arrange(new Rect(new Point(0, 0), finalSize));
      return new Size(_child.ActualWidth, _child.ActualHeight);
    }
