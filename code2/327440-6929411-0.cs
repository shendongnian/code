    void checkPressure(InkCanvas inkcan)
    {
    //return if touch is lifted code here
    
    DrawingAttributes dattribute = new DrawingAttributes();
    if (stylusInput.pressureFactor < 0.5)
    dattribute.Color = Colors.Red;
    else
    dattribute.Color = Colors.Blue;
    inkcan.DefaultDrawingAttributes = dattribute;
    this.Dispatcher.BeginInvoke(new MyPressureDelegate(checkPressure), DispatcherPriority.ApplicationIdle, inkcan);
    }
