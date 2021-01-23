    using System.Windows.Interop;
    private const int WM_MOUSEMOVE = 0x0200;
    public delegate void Del_MouseMovedEvent(Point mousePosition);
    public IInputElement Elmt_MouseMovedRelativeElement = null;
	
	// !! This is static; needs special treatment in a multithreaded application !!
    public static event Del_MouseMovedEvent Evt_TheMouseMoved = null;
	// your main function call
	public MyMainWindows()
	{
        // install the windows message filter first
		ComponentDispatcher.ThreadFilterMessage += ComponentDispatcher_ThreadFilterMessage;
		InitializeComponent();
		
		...
	}	
	
	// filtering the windows messages
	private void ComponentDispatcher_ThreadFilterMessage(ref MSG msg, ref bool handled)
	{
		if(msg.message == WM_MOUSEMOVE)
		{
			this.Evt_TheMouseMoved?.Invoke(Mouse.GetPosition(this.Elmt_MouseMovedRelativeElement));
		}
	}
	// individual event for mouse movement
	private void MyMouseMove(Point mousePoint)
	{
		// called on every mouse move when event is assigned
		Console.WriteLine(mousePoint.X + " " + mousePoint.Y);
	}
	private void AnyFunctionDeeperInTheCode()
	{
		// assign the handler to the static var of the main window
		MyMainWindows.Evt_TheMouseMoved += MyMouseMove;
		
		...
		
		// undassign the handler from the static var of the main window
		MyMainWindows.Evt_TheMouseMoved -= MyMouseMove;
	}
