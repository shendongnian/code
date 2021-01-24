    public AdInterstitial_Droid()
    {
        interstitialAd = new InterstitialAd(Android.App.Application.Context);
        interstitialAd.AdListener = new MyAdListener(() =>
        {
            // Ad closing, do whatever you need to do
        });
        // TODO: change this id to your admob id  
        interstitialAd.AdUnitId = "xxxxx";
        LoadAd();
    }
