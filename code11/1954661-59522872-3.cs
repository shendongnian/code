     public int SendImage(string TweetText, List<long> TweetIDs, byte[] binData)  
            {
                //I'm passing the byte object "binData" to be 
                //converted back to an image stream in the foreach block
    
                TwitterService service = twitterAPI.Twitterservice();
    
                GetTweetOptions tweetOptions = new GetTweetOptions();
    
                try
                {
                    foreach (long _tweetid in TweetIDs)
                    {
                        tweetOptions.Id = _tweetid;
    
                        TwitterUser twitteruser = service.GetTweet(tweetOptions).User;
    
                        try
                        {    
