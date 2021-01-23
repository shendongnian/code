    namespace IsoStore
    {
	 public partial class MainPage : PhoneApplicationPage
	 {
		static IsolatedStorageSettings.ApplicationSettings appSettings;
		// Constructor
		public MainPage()
		{
		InitializeComponent();
		appSettings = IsolatedStorageSettings.ApplicationSettings;
		}
		private void button1_Click(object sender, RoutedEventArgs e)
		{
		appSettings.Add("email", "someone@somewhere.com");
		}
		private void button2_Click(object sender, RoutedEventArgs e)
		{
		textBlock1.Text = (string)appSettings["email"];
		}
	  }
    }
