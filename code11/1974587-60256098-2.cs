      public StartPage()
        {
            InitializeComponent();
            this.BindingContext = new StartViewModel();
        }
        private async void btnPlay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
