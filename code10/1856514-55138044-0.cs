    public void QuitAd(TypeOfAd typeOfAd)
    {
        switch (typeOfAd)
        {
            case TypeOfAd.Banner:
                Debug.Log("Quiting Banner ad");
                bannerAd.Destroy();
                break;
            case TypeOfAd.Interestitial:
                Debug.Log("Quiting Interestitial ad");
                Debug.LogError("QuitAd Interestitial Not Implemented");
                break;
            case TypeOfAd.RewardedVideo:
                Debug.Log("Quiting RewardedVideo ad");
                Debug.LogError("QuitAd RewardedVideo Not Implemented");
                break;
        }
    }
