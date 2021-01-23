	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			foreach (var item in x.Items)
			{
				var menuItem = ((MenuItem)item);
				//menuItem.MouseRightButtonDown += MainWindow_MouseRightButtonDown;
				menuItem.AddHandler(UIElement.MouseRightButtonDownEvent, new RoutedEventHandler(MainWindow_MouseRightButtonDown), true);
			}
		}
		void MainWindow_MouseRightButtonDown(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("Handled:{0}\r\nOriginalSource: {1}\r\nSource:{2}\r\nRoutedEvent:{3}", 
						e.Handled, e.OriginalSource, e.Source, e.RoutedEvent);
		}
	}
