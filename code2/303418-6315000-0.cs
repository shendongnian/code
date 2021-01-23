    protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
    {
       this.CaptureMouse();
        //Show slider here
    }
    protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
    {
       this.ReleaseMouseCapture();
        //Hide slider here and get it's value
    }
    Point previousMousePosition;
    protected override void OnPreviewMouseMove(MouseEventArgs e)
    {
        if (this.IsMouseCaptured)
        {
            Point point = e.GetPosition(this);
            
            double d = point.X - previousMousePosition.X;
            
            //you can use this value to change the slider's value
            this.previousMousePosition = point;
        }
    }
