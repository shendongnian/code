    SubscribeToMouseEvents(FrameworkElement other)
    {
     other.MouseEnter += MouseEnterHandler;
     other.MouseMove += MouseMoveHandler;
     other.MouseLeave += MouseLeaveHandler;
    }
