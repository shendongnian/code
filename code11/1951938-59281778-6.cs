      [XamlCompilation(XamlCompilationOptions.Compile)]
	  public partial class BaseContentPage : ContentPage
	{
		public BaseContentPage ()
		{
			InitializeComponent ();
            if (Device.RuntimePlatform == "Android")
            {
                NavigationPage.SetHasBackButton(this, false);
                NavigationPage.SetTitleView(this, SetTitleView("Morning \n 9.30 Am"));
            }
            else
            {
                Title = "Morning \n 9.30 Am";
            }
        }
        StackLayout SetTitleView(string title)
        {
            Button button = new Button()
            {
                Text = "Back",
                TextColor = Color.White,
                FontAttributes = FontAttributes.None,
                BackgroundColor = Color.Transparent,
            };
            button.Clicked += Button_Clicked;
            StackLayout TitleView = new StackLayout()
            {
                Margin = new Thickness(-20, 0, 0, 0),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Start,
                Children = {
                    button,
                    new Label(){
                        Text = title,
                        TextColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        WidthRequest = 200,
                    }
                }
            };
            return TitleView;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
