    public class AdViewRenderer : ViewRenderer<AdControlView, AdControl>
    {
        string bannerId = "test";
        AdControl adView;
        string applicationID = "3f83fe91-d6be-434d-a0ae-7351c5a997f1";
        bool isRegist = false;
    
        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);
    
            if (Control == null && isRegist != true)
            {
                CreateNativeAdControl();
                SetNativeControl(adView);
                isRegist = true;
            }
        }
        private void CreateNativeAdControl()
        {
            if (adView != null)
                return;
    
            var width = 300;
            var height = 50;
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop")
            {
                width = 728;
                height = 90;
            }
            // Setup your BannerView, review AdSizeCons class for more Ad sizes. 
            adView = new AdControl
            {
                ApplicationId = applicationID,
                AdUnitId = bannerId,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom,
                Height = height,
                Width = width
            };
        }
    }
