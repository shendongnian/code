        public ActionResult FBAuthorize()
        {
            FacebookOAuthClient cl = new FacebookOAuthClient(FacebookContext.Current);
            FacebookOAuthResult result = null; 
            string url = Request.Url.OriginalString;
            // verify that there is a code in the url
            if (FacebookOAuthResult.TryParse(url, out result))
            {
                if (result.IsSuccess)
                {                                       
                    string code = result.Code;
                    // this line is necessary till they fix a bug *see details below
                    cl.RedirectUri = new UriBuilder("http://localhost:5000/account/FBAuthorize").Uri;
                    var parameters = new Dictionary<string, object>();
                    //parameters.Add("permissions", "offline_access");
                    Dictionary<String, Object> dict = (Dictionary<String, Object>)cl.ExchangeCodeForAccessToken(code, new Dictionary<string, object> { { "redirect_uri", "http://localhost:5000/account/FBAuthorize" } });
                    Object Token = dict.Values.ElementAt(0);
                    TempData["accessToken"] = Token.ToString();
                    return RedirectToAction ("ShowUser");
                }
                else
                {
                    var errorDescription = result.ErrorDescription;
                }
            }
            else 
            {
                // TODO: handle error
            }             
            return View();
        }
