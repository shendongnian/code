        public void HandleRewardedAdClosed(object sender, EventArgs args)
        {
            // simply give unity control back.
            // you can pick and choose to execute what on main thread,
            // but I'm just gonna dispatch the whole block.
            MainThreadDispatcher.Dispatch(() =>
            {
                MonoBehaviour.print("HandleRewardedAdClosed event received");
    
                Debug.Log("{lo} OnClosed called sender = " + sender);
    
                RequestRewardedVideo();
    
                gameManager.CheckForLives();
    
                this.RewardPanel.SetActive(true);
            });
        }
