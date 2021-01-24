     public partial class MainPage : ContentPage
    {
        public int count;
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Btn1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            count++;
            if(count>1)
            {
                InitializeComponent();
            }
           
        }
    }
