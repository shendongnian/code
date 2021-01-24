       public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
    string type = args.Type;
    double amount = args.Amount;
    Debug.Log(
        "HandleRewardBasedVideoRewarded event received for "
        + amount.ToString() + " " + type);
      StartCoroutine(AfunctionName());
    }
    IEnumerator AfunctionName()
    {
     yield return new WaitForSecondsRealtime(0.1f);
    
     // FB.LogAppEvent("AdmobRewardedView");
        Debug.Log("Reward Function Called!!!!!");
        GiveReward();
    
        this.RequestRewardBasedVideo();
    }
