    private bool _touchDown = false;
    private double _initOffset = 0;
    private double _scrollDelta = 5;
    
    private void ListView_PreviewTouchDown(object sender, TouchEventArgs e) 
    {
    	_touchDown = true;
    	_initOffset = e.GetTouchPoint(this).Y;
    }
    
    private void ListView_PreviewTouchMove(object sender, TouchEventArgs e) 
    {
    	if (_touchDown && Math.Abs(r.GetTouchpoint(this).Y - _initOffset) > _scrollDelta) 
    	{
    		My_ScrollViewer.ScrollToVerticalOffset(r.GetTouchpoint(this).Y - _initOffset);
    		My_ListView.UnselectAll();
    	}
    }
    
    private void ListView_PreviewTouchUp(object sender, TouchEventArgs e) 
    {
    	_touchDown = false;
    	_initOffset = 0;
    }
