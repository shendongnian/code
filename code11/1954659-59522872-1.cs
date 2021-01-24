     public int SendImage(string TweetText, List<long> TweetIDs, byte[] binData)  
            {
                //I'm passing the byte object
    
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
                            //  I'm converting the byte object to an image stream here then adding it to the dictionary within the foreach statement
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
