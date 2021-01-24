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
                           Stream st = new MemoryStream(binData);
    
                            Dictionary<string, Stream> _images = new Dictionary<string, Stream> { { "mypicture", st } };
    
                            service.SendTweetWithMedia(new SendTweetWithMediaOptions { Status = "@" + twitteruser.ScreenName + " " + TweetText, InReplyToStatusId = _tweetid, Images = _images });
    
                        }
                        catch (Exception ex)
                        {
    
                            return 1;
                        }
                    }
    
                }
                catch (Exception ex)
                {
                    return 1;
    
                }
    
                return 0;
    
            }
