            var access_code = app.Request.QueryString["code"];
            if (access_code == null)
            {
                return;
            }
            var serv = app.Request.Url.GetLeftPart(UriPartial.Authority);
            var access_token = "";
            
            if (!GetAccessToken(access_code, HttpUtility.UrlEncode(serv + "/index.html?action=google"), out access_token))
            {
                return;
            }
            var res = "";
            var web = new WebClient();
            web.Encoding = System.Text.Encoding.UTF8;
            try
            {
                res = web.DownloadString("https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + access_token);
            }
            catch (Exception ex)
            {
                return;
            }
