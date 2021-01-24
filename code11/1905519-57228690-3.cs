    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			userControl.InnerButton.Click += Button_Click;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Thank you!");
		}
	}
