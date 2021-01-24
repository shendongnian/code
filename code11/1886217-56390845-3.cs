     public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
          btn.Clicked += Btn_Clicked;
        }
      
        private async void Btn_Clicked(object sender, EventArgs e)
        {
           
            if (popupLoginView.IsVisible==true)
            {
                btn.IsEnabled = false;
                  await popupLoginView.FadeTo(0,2000);
                await Task.Delay(2000);
                popupLoginView.Opacity = 0;
                popupLoginView.IsVisible = false;
                btn.IsEnabled = true;
                return;
             
            }
            if (popupLoginView.IsVisible == false)
            {
                
                if (popupLoginView.Opacity==1)
                {
                    popupLoginView.Opacity = 0;
                }
               
                popupLoginView.IsVisible = true;
                btn.IsEnabled = false;
                await popupLoginView.FadeTo(1, 2000);
                  await Task.Delay(2000);
                btn.IsEnabled = true;
                popupLoginView.Opacity = 1;
                return;
               
            }
          
        }
    }
