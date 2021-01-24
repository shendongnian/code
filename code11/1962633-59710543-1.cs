    public partial class MainPage : AnimationPage
    {
      public MainPage()
       {
        InitializeComponent();
       }
      private async void Button_Clicked(object sender, EventArgs e)
       {
        await Navigation.PushAsync(new Page1());
       }
    }
