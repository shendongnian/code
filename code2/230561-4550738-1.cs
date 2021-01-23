    namespace IsoStore
    {
	 public partial class MainPage : PhoneApplicationPage
	 {
		
		// Constructor
		public MainPage()
		{
		InitializeComponent();
		
		}
		private void button1_Click(object sender, RoutedEventArgs e)
		{
		IsolatedStorageSettings.ApplicationSettings.Add("email", "someone@somewhere.com");
		}
		private void button2_Click(object sender, RoutedEventArgs e)
		{
		   textBlock1.Text = (string)IsolatedStorageSettings.ApplicationSettings["email"];
		}
	  }
    }
