	public MainWindow()
	{
		InitializeComponent();
		var userCTL = new UserControl();    // <-- replace with your own control
		userCTL.Background = Brushes.Blue;	// <-- added this so I can see it
		userCTL.Width = 50;
		userCTL.Height = 100;
		Canvas.SetTop(userCTL, 20);
		Canvas.SetLeft(userCTL, 20);
		userCTL.PreviewMouseDown += UserCTL_PreviewMouseDown;
		CanvasMain.Children.Add(userCTL);
	}
	UIElement dragObject = null;
	Point offset;
	private void UserCTL_PreviewMouseDown(object sender, MouseButtonEventArgs e)
	{
		this.dragObject = sender as UIElement;
		this.offset = e.GetPosition(this.CanvasMain);
		this.offset.Y -= Canvas.GetTop(this.dragObject);
		this.offset.X -= Canvas.GetLeft(this.dragObject);
		this.CanvasMain.CaptureMouse();
	}
	private void CanvasMain_PreviewMouseMove(object sender, MouseEventArgs e)
	{
		if (this.dragObject == null)
			return;
		var position = e.GetPosition(sender as IInputElement);
		Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
		Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
	}
	private void CanvasMain_PreviewMouseUp(object sender, MouseButtonEventArgs e)
	{
		this.dragObject = null;
		this.CanvasMain.ReleaseMouseCapture();
	}
