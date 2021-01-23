    DateTime lastMouseDown = DateTime.MinValue;
    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        if(DateTime.Now.Subtract(lastMouseDown).TotalMilliseconds < 50)
           return;
        lastMouseDown = DateTime.Now;
        HandleKeyDown();
        base.OnMouseDown(e);
    }
