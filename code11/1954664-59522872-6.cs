//This is the method that calls the SendImage method
//Note that the file is converted to a byte object
//then that will be sent to the SendImage method
[HttpPost]
        public ActionResult TweetImage(string TweetText)
        {
            var file = Request.Files[0];            
            //// Read bytes from http input stream
           BinaryReader b = new BinaryReader(file.InputStream);
          byte[] binData = b.ReadBytes(file.ContentLength);
            var tweetIDs = (List<long>)TempData["TweetIDList"];
            tweetsend.SendImage(TweetText, tweetIDs, binData);
            return View("SendTweetsByString");
        }
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
-------------------------------------------------------------------------------------
You could copy it to a MemoryStream. This won't solve the problem with it being disposed, but it gives you access to the data as a byte[] if needs be. – John_ReinstateMonica Dec 16 at 2:35 
  [1]: https://stackoverflow.com/users/3181933/john-reinstatemonica
