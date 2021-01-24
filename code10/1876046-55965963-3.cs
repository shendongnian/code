    public WindowB()
    {
    	PreviewMouseDown += WindowB_PreviewMouseDown;
    	StateChanged += WindowB_StateChanged;
    	InitializeComponent();
    	LostMouseCapture += WindowB_LostMouseCapture;
    			
    }
    
    private void WindowB_LostMouseCapture(object sender, MouseEventArgs e)
    {
    	//You can also evaluate here a mouse coordinates.
    	if (WindowState == WindowState.Minimized)
    	{
    		e.Handled = true;
    		CaptureMouse();
    	}
    }
    
    private void WindowB_StateChanged(object sender, EventArgs e)
    {
    	if (WindowState== WindowState.Minimized)
    	{
    		CaptureMouse();
    	}
    	else
    	{
    		ReleaseMouseCapture();
    	}
    }
    
    private void WindowB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
    	WindowState = WindowState.Normal;
    	Debug.WriteLine("WindowB PreviewMouseDown");
    }
