    private string formatTweetText(string tweet)
        {
            Regex regUrl = new Regex(@"http://\S+");
            string url = regUrl.Match(tweet).Value;
            if (url.Length > 0)
            {
                string newReturnVal = string.Format("<font color=\"#FF0000\">{0}</font>", url);
                string returnVal =  tweet.Replace(url, newReturnVal);
                return returnVal;
            }
            else
            {
                return tweet;
            }
  
        }
