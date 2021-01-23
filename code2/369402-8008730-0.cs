    private Key mPressedKey;
    
    protected override void OnKeyDown(KeyEventArgs e)
    {
    	base.OnKeyDown(e);
    	
    	mPressedKey = e.Key;
    }
    
    protected override void OnTextInput(TextCompositionEventArgs e)
    {
    	base.OnTextInput(e);
    	
    	// ... Handle mPressedKey here ...
    }
    
    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
    	base.OnMouseDown(e);
    	
    	// Force focus back to main window
    	FocusManager.SetFocusedElement(this, this);
    }
