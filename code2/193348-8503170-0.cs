    void OnPreviewTouchDown(object sender, System.Windows.Input.TouchEventArgs e)
    {
    if(e.Source.GetHashCode() == YourUIElement.GetHashCode() )
    { 
    MyTimer.Start();
    
    //You need to capture the touch before the ScatterViewItem handles its own touch which will    
    //block you from receiving the touch up event 
    YourUIElement.CaptureTouch(e.TouchDevice);
    e.Handled = true;
          
    }
    }
            
    void OnPreviewTouchUp(object sender, System.Windows.Input.TouchEventArgs e)
    {
    YourUIElement.ReleaseAllTouches();
    }
              
            
    private void OnTimerTick(object sender, EventArgs e)
    {
    // To call whatever function or do whatever action you need.
    IsTapHoldGestureOkay = true;
    DoStuff();
    MyTimer.Stop();
    }
