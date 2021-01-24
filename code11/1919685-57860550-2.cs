    static XYController()
    {
        UIElement.VisibilityProperty.OverrideMetadata(
        typeof(XYController),
        new PropertyMetadata(Visibility.Visible, OnVisibililtyChanged));
        DefaultStyleKeyProperty.OverrideMetadata(typeof(XYController), new FrameworkPropertyMetadata(typeof(XYController)));
        EventManager.RegisterClassHandler(typeof(XYController), Thumb.DragDeltaEvent, new DragDeltaEventHandler(XYController.OnThumbDragDelta));
    }
    private static void OnVisibililtyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      // Update control
      OnThumbPosChanged(d, null);
      // Do more updates
    }
