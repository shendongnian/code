    // Add this transform to the image as RenderTransform
    private TranslateTransform _translateT = new TranslateTransform();
    private Point _lastMousePos = new Point();
    private void This_MouseDown(object sender, MouseButtonEventArgs 
    {
    	if (e.ChangedButton == PanningMouseButton)
    	{
    		this.Cursor = Cursors.ScrollAll;
    		_lastMousePos = e.GetPosition(null);
    		this.CaptureMouse();
    	}
    }
    
    private void This_MouseUp(object sender, MouseButtonEventArgs e)
    {
    	if (e.ChangedButton == PanningMouseButton)
    	{
    		this.ReleaseMouseCapture();
    		this.Cursor = Cursors.Arrow;
    	}
    }
    
    private void This_MouseMove(object sender, MouseEventArgs e)
    {
    	if (this.IsMouseCaptured)
    	{
    		Point newMousePos = e.GetPosition(null);
    		Vector shift = newMousePos - _lastMousePos;
    		_translateT.X += shift.X;
    		_translateT.Y += shift.Y;
    		_lastMousePos = newMousePos;
    	}
    }
