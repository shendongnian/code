    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
        }
    
       int taps = 0;
        private void OnTapped(object sender, EventArgs e)
        {
            taps++;
            Console.Writeline(taps.ToString());
        }
    }
