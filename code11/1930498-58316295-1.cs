    <ContentPage
    x:Class="demo2.simplecontrol.Page7"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">
    <ContentPage.Content>
        <StackLayout x:Name="stacklayout1">
            <Label
                HorizontalOptions="CenterAndExpand"
                Text="Welcome to Xamarin.Forms!"
                VerticalOptions="CenterAndExpand" />
            <Button
                x:Name="btn1"
                Clicked="Btn1_Clicked"
                Text="create button" />
        </StackLayout>
    </ContentPage.Content>
    </ContentPage>
    public partial class Page7 : ContentPage
	{     
		public Page7 ()
		{
			InitializeComponent ();
            MessagingCenter.Subscribe<Page7, string>(this, "add", (sender, arg) =>
            {
                Button btn = new Button()
                {
                    Text = (string)arg
                    
                };
                stacklayout1.Children.Add(btn);
            });
         
		}
       
        private async void Btn1_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Page8());
        }
    }
