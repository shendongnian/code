       public partial class MainPage : ContentPage
      {
        public MainPage()
        {
            InitializeComponent();
        
            MessagingCenter.Subscribe<Stream>(this, "Image", (arg) =>
            {
                MyImage.Source = ImageSource.FromStream(() => arg);
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private  void Mybutton_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new SignaturesPage());
        }
    }
