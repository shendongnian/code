    using System;
    using System.Collections.Generic;
    
    using Xamarin.Forms;
    
    namespace XamarinTest.View
    {
        public partial class WebViewDemo : ContentPage
        {
            public WebViewDemo()
            {
                InitializeComponent();
            }
            protected override void OnAppearing()
            {
                base.OnAppearing();
    
            }
    
            protected override void OnSizeAllocated(double width, double height)
            {
                base.OnSizeAllocated(width, height);
                WebViewer.HeightRequest = height;
                WebViewer.WidthRequest = width;
    
            }
        }
    }
