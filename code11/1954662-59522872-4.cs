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
