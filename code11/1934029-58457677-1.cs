    public partial class MainPage : ContentPage
    {
        int lblValue = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void Increment(object sender, EventArgs e)
        {
            lblValue++;
            lblCount.Text = lblValue.ToString();
        }
    }
