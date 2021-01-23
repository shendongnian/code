        TwitterService service = new TwitterService(consumerKey, consumerSecret);
        service.AuthenticateWith(accessToken, accessTokenSecret);
        if (thumbnail != null)  // an image post - go through twitpic
        {
            MemoryStream ms = new MemoryStream();
            thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Seek(0, SeekOrigin.Begin);
            // Prepare an OAuth Echo request to TwitPic
            RestRequest request = service.PrepareEchoRequest();
            request.Path = "uploadAndPost.xml";
            request.AddField("key", twitpicApiKey);
            request.AddField("consumer_token", consumerKey);
            request.AddField("consumer_secret", consumerSecret);
            request.AddField("oauth_token", accessToken);
            request.AddField("oauth_secret", accessTokenSecret);
            request.AddField("message", "Failwhale!");
            request.AddFile("media", "failwhale" + Environment.TickCount.ToString(), ms, "image/jpeg");
            // Post photo to TwitPic with Hammock
            RestClient client = new RestClient { Authority = "http://api.twitpic.com/", VersionPath = "1" };
            RestResponse response = client.Request(request);
            return response.Content;
        }
