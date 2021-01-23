            public void FacebookLike(AppConnect appconnect )
        {
            try
            {
                Dictionary<string, string> tokens = new Dictionary<string, string>();
                string fb_exchange = appconnect.UserToken;
                string url =
                string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&grant_type=fb_exchange_token&fb_exchange_token={3}&redirect_uri=https://www.facebook.com/connect/login_success.html&scope={1}&client_secret={2}",
                appconnect.AppID, appconnect.ExtendedPermissions, appconnect.AppSecret, fb_exchange);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string vals = reader.ReadToEnd();
                    foreach (string token in vals.Split('&'))
                    {
                        //meh.aspx?token1=steve&token2=jake&...
                        tokens.Add(token.Substring(0, token.IndexOf("=")),
                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                    }
                }
                string access_token = tokens["access_token"];
                var client = new FacebookClient(access_token);
                dynamic parameters = new ExpandoObject(); parameters.idobject = "";
                
                client.Post("/" + appconnect.AppID.ToString() + "_" + appconnect.PostID.ToString() + "/Likes", parameters);
               // MessageBox.Show("....... Done ..........");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"\n"+ex.InnerException);
            }
            
        }
     class AppConnect
    {
        //tring appId, string Appsecret, string userToken, string userID, string PostID
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public  string AppID { get; set; } = "991341734653453831";
        public  string AppSecret { get; set; } = "99dfbf29234ergec4a";
        public string UserID { get; set; } = null;
        public  string UserToken { get; set; } = null; 
        public  string PostID { get; set; } = null;
        public  string ExtendedPermissions { get; set; } = "user_posts, publish_actions, publish_pages,manage_pages,user_likes";
    }
