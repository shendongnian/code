    //reference Twitterizer2.dll
    var tokens = new Twitterizer.OAuthTokens {
        AccessToken = @"myAccessToken",
        AccessTokenSecret = @"myAccessTokenSecret",
        ConsumerKey = @"myConsumerKey",
        ConsumerSecret = @"myConsumerSecret"
    };
    
    // Post the update to twitter
    var statusResponse = Twitterizer.TwitterStatus.Update(tokens, 
        "I am your status update!");
    if (statusResponse.Result != Twitterizer.RequestResult.Success)
        return;
    // Fetch the authenticated user's timeline, uses statuses/user_timeline
    // under the hood
    var timelineResponse = Twitterizer.TwitterTimeline.UserTimeline(tokens);
    if (timelineResponse.Result != Twitterizer.RequestResult.Success)
        return;
	
    foreach (var status in timelineResponse.ResponseObject)
    {
        Console.WriteLine(status.Text);
    }
