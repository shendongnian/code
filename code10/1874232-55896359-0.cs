    public partial class MainPage : ContentPage
    {
        public Entry previousEntry;
        public MainPage()
        {
            InitializeComponent();
            first.Unfocused += (object sender, FocusEventArgs e) => {
                previousEntry = (Entry)sender;
            };
            second.Unfocused += (object sender, FocusEventArgs e) => {
                previousEntry = (Entry)sender;
            };
            third.Unfocused += (object sender, FocusEventArgs e) => {
                previousEntry = (Entry)sender;
            };
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
           
            Button button = (Button)sender;
            string pressed = button.Text;
            if (previousEntry != null)
            {
                previousEntry.Text += pressed;
            }
        }    
    }
