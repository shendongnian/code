    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<MainPage>(this, "Hi", async (sender) =>
            {
                await Task.Delay(2000); // 2000ms == 2s
                entEncodedBy.Text = "Admin";
            });
        }
        protected override  void OnAppearing()
        {
            base.OnAppearing();
           
            MessagingCenter.Send<MainPage>(this, "Hi");
        }
    }
