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
              
                await popupLoginView.FadeTo(0,2000);
                await Task.Delay(2000);
                popupLoginView.Opacity = 0;
                popupLoginView.IsVisible = false;
                return;
             
            }
            if (popupLoginView.IsVisible == false)
            {
                  
                popupLoginView.Opacity = 1;
                popupLoginView.IsVisible =true;
                return;
               
            }
          
        }
    }
