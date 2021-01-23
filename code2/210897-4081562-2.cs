    private string formatTweetText(string tweet)
        {
          
            string returnVal = tweet;
            string updatedValue = tweet;
            Regex regUrl = new Regex(@"http://\S+");
            Match matches = regUrl.Match(tweet);
            while (matches.Success)
            {
                for (int i = 0; i <= 2; i++)
                {
                    Group g = matches.Groups[i];
                    CaptureCollection cc = g.Captures;
                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        string url = c.Value;
                        if (c.Length > 0)
                        {
                            string newReturnVal = string.Format("<font color=\"#FF0000\">{0}</font>", url);
                            returnVal = updatedValue.Replace(url, newReturnVal);
                            
                        }
                        updatedValue = returnVal;
                    }   
                  
                }
                matches = matches.NextMatch();
            }
            return returnVal;
        }
