    public partial class SecondPage : ContentPage
    {
        public string previousPageValue; //Declare here
        public SecondPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            label.Text = previousPageValue;
        }
    }
