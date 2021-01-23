    public partial class MainPage : UserControl
	{
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
		}
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mainpage pressed!!");
        }
        private void LoginBox_LoggedIn(object sender, userNameEventArgs e)
        {
            textBlock1.Text = e.userName;
        }
	}
