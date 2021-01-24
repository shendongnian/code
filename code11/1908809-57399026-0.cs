    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Plugin.Connectivity;
    
    namespace MyApp
    {
    
        [DesignTimeVisible(true)]
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
                CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            }
    
            protected async override void OnAppearing()
            {
                base.OnAppearing();
    
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("Error Title", "Error Msg", "OK");
                }
                else
                {
                    Broswer.Source = "https://mypage.com/";
                }
            }
    
            private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
            {
                if (!e.IsConnected)
                {
                    await DisplayAlert("Error Title", "Error Msg", "OK");
                }
                else
                {
                    Broswer.Source = "https://mypage.com/";
                }
            }
    
            protected override bool OnBackButtonPressed() 
            {
                if (Broswer.CanGoBack)
                {
                    Broswer.GoBack();
                    return true;
                }
                return false;
            }
        }
    }
