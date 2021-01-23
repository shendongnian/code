        public static string search()
        {
            string yelpSearchURL = "http://api.yelp.com/v2/search?term=food&location=San+Francisco";
            string yelpConsumerKey = "your key";
            string yelpConsumerSecret = "your secret";
            string yelpRequestToken = "your token";
            string yelpRequestTokenSecret = "your token secret";
            Twitterizer.OAuthTokens ot = new Twitterizer.OAuthTokens();
            ot.AccessToken = yelpRequestToken;
            ot.AccessTokenSecret = yelpRequestTokenSecret;
            ot.ConsumerKey = yelpConsumerKey;
            ot.ConsumerSecret = yelpConsumerSecret;
            
            string formattedUri = String.Format(CultureInfo.InvariantCulture,
                                 yelpSearchURL, "");
            Uri url = new Uri(formattedUri);
            Twitterizer.WebRequestBuilder wb = new Twitterizer.WebRequestBuilder(url, Twitterizer.HTTPVerb.GET, ot);
            System.Net.HttpWebResponse wr = wb.ExecuteRequest();
            StreamReader sr = new StreamReader(wr.GetResponseStream());
            return sr.ReadToEnd();
        }
