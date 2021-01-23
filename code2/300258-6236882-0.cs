    var twitterCtx = new TwitterContext();
    
                var publicTweets =
                    from tweet in twitterCtx.Status
                    where tweet.Type == StatusType.Public
                    select tweet;
    
                publicTweets.ToList().ForEach(
                    tweet => Console.WriteLine(
                        "User Name: {0}, Tweet: {1}",
                        tweet.User.Name,
                        tweet.Text));
