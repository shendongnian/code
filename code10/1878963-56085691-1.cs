    using System;
    
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    namespace MyApp
    {
    	[XamlCompilation(XamlCompilationOptions.Compile)]
    	public partial class Page1 : ContentPage
    	{
    		public Page1 ()
    		{
    			InitializeComponent ();
    		}
    
            private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
            {
                priceStack.IsVisible = !priceStack.IsVisible;
            }
    
            private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
            {
                await App.Current.MainPage.DisplayAlert("Confirmation", "Should we send the order?", "Yes", "Cancel");
            }
        }
    }
