    public static HitTestFilterBehavior HitTestFilterInvisible(DependencyObject potentialHitTestTarget)
    {
    	bool isVisible = false;
    	bool isHitTestVisible = false;
    
    	var uiElement = potentialHitTestTarget as UIElement;
    	if (uiElement != null)
    	{
    		isVisible = uiElement.IsVisible;
    		if (isVisible)
    		{
    			isHitTestVisible = uiElement.IsHitTestVisible;
    		}
    	}
    	else
    	{
    		UIElement3D uiElement3D = potentialHitTestTarget as UIElement3D;
    		if (uiElement3D != null)
    		{
    			isVisible = uiElement3D.IsVisible;
    			if (isVisible)
    			{
    				isHitTestVisible = uiElement3D.IsHitTestVisible;
    			}
    		}
    	}
    
    	if (isVisible)
    	{
    		return isHitTestVisible ? HitTestFilterBehavior.Continue : HitTestFilterBehavior.ContinueSkipSelf;
    	}
    
    	return HitTestFilterBehavior.ContinueSkipSelfAndChildren;
    }
    ...
    // usage:
    
        VisualTreeHelper.HitTest(
        	myHitTestReference,
        	HitTestFilterInvisible,
        	hitTestResult =>
        	{
        		// code to handle element which is visible to the user and enabled for hit testing.
        	},
        	new PointHitTestParameters(myHitTestPoint));
