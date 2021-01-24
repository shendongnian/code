    public bool ShowAd(TypeOfAd typeOfAd)
    {
        if (DataManager.instance.showAds)
            switch (typeOfAd)
            {
                case TypeOfAd.Banner:
                    Debug.Log("Showing Banner ad");
                    LoadAd(TypeOfAd.Banner); //Every time the banner is asked to be shown it will try to load before being shown.
                    this.bannerAd.Show(); //Will be show after loading
                    return true;
                case TypeOfAd.Interestitial:
                    Debug.Log("Showing Interestitial ad");
                    if (this.interstitialAd.IsLoaded())
                    {
                        this.interstitialAd.Show();
                        return true;
                    }
                    else
                    {
                        Debug.LogWarning("Trying to show InterstitialAd but it is not loaded");
                        //TBD: Automaitcally load?
                    }
                    break;
                case TypeOfAd.RewardedVideo:
                    Debug.Log("Showing RewardedVideo ad");
                    if (this.rewardedVideoAd.IsLoaded())
                    {
                        this.rewardedVideoAd.Show();
                        return true;
                    } else {
                        Debug.LogWarning("Trying to show RewardedBasedVideoAd but it is not loaded");
                        //TBD: Automaitcally load?
                    }
                    break;
            }
        return false;
    }
