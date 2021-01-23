    //reference Twitterizer2.dll
    var tokens = new Twitterizer.OAuthTokens {
      ConsumerKey = @"consumerKey",
      ConsumerSecret = @"consumerSecret",
      AccessToken = @"accessToken",
      AccessTokenSecret = @"accessTokenSecret"
    };
    
    var response = Twitterizer.TwitterSearch.Search(tokens, "test", 
      new Twitterizer.SearchOptions { 
        GeoCode = "51.50788772102843,-0.102996826171875,50mi" 
      });
    if (response.Result != Twitterizer.RequestResult.Success)
      return;
    foreach (var status in response.ResponseObject)
    {
      Console.WriteLine(status.Text);
    }
