	public MainWindow()
		{
			InitializeComponent();
            //Additional rectangle for testing.
			Rectangle r3 = new Rectangle() { Width = 175, Height = 80, Fill = Brushes.Goldenrod };
			Canvas.SetLeft(r3, 80);
			Canvas.SetTop(r3, 80);
			canvas1.Children.Add(r3);
			Rectangle r1 = new Rectangle() { Width = 80, Height = 120, Fill = Brushes.Blue };
			RotateTransform rt1 = new RotateTransform(60);
			r1.RenderTransform = rt1;
			Canvas.SetLeft(r1, 100);
			Canvas.SetTop(r1, 100);
			canvas1.Children.Add(r1);
			Rectangle r2 = new Rectangle() { Width = 150, Height = 50, Fill = Brushes.Green };
			RotateTransform rt2 = new RotateTransform(15);
			r2.LayoutTransform = rt2;
			Canvas.SetLeft(r2, 100);
			Canvas.SetTop(r2, 100);
			canvas1.Children.Add(r2);
            //Mouse 'click' event.
			canvas1.PreviewMouseDown += canvasMouseDown;
		}
        //list to store the hit test results
		private List<HitTestResult> hitResultsList = new List<HitTestResult>();
