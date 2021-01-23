    public virtual ActionResult FbCallback()
            {
                var code = Request.QueryString["code"];
    
                if (!string.IsNullOrEmpty(code))
                {
                    
                    string query = "client_id=" + Facebook.FacebookApplication.Current.AppId + "&client_secret=" +
                        Facebook.FacebookApplication.Current.AppSecret + "&redirect_uri=" + Server.UrlEncode(GetFacebookCallbackUrl()) +
                        "&code=" + code;
    
                    var response = WebRequestHelper.GetWebRequest("https://graph.facebook.com/oauth/access_token?" + query);
                    //Process response here.
                }
    
                else
                {
                    var errorReason = Request.QueryString["error_reason"];
                    var error = Request.QueryString["error"];
                    
                    ContentResult res = new ContentResult();
                    res.Content = "code query string does not present. reason: " + errorReason;
                    res.ContentType = "text/plain";
                    return res;
                }
            }
