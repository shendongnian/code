    public async void onButtonClick(object sender, EventArgs args) {
        //Non-blocking call
        var tweetRequestCode = await PostStatusRequestAsync(TweetText, AuthUtils.GetResourceUrl(), AuthUtils.GetWebRequestHeader())); 
    
        //back on UI thread
        //...
    }
