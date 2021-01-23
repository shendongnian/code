    if (this.Request.QueryString["facebookAuth"] == "true")
    {
        var parameters = new Dictionary<string,object>();
        parameters["client_id"] = "...";
        // parameters["scope"] = "email";
                
        string state = Guid.NewGuid().ToString();
        parameters["state"] = state;
        this.Session.Add("state", state); //CSRF protection
                
        parameters["redirect_uri"] =    
          this.Request.Url.AbsoluteUri.Replace("facebookAuth=true", "facebookAuth=false");
        parameters["response_type"] = "code"; // code can be exchanged for an access token
        
        parameters["display"] = "popup";
        this.Response.Redirect(new FacebookClient().GetLoginUrl(parameters).AbsoluteUri);
    }
    else
    {
        string code = this.Request.QueryString["code"];
        string state = this.Request.QueryString["state"];
        string currentState = (this.Session["state"] != null ? 
            this.Session["state"].ToString() : null);
        if (string.IsNullOrWhiteSpace(code) == true)
        {
            // set info in session: app not authorized & inject close window JS script
            return;
        }
        if (string.IsNullOrWhiteSpace(state) == true || 
            string.IsNullOrWhiteSpace(currentState) == true)
        {
            // session state expired & inject close window JS script
            return;
        }
        if (state != currentState)
        {
            throw new ArgumentException("State does not match (CSRF?)");
        }
        //// get access token
        var fb = new FacebookClient();
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("client_id", "...");
        parameters.Add("redirect_uri", "https://127.0.0.1
           /AuthSocialUser.aspx?facebookAuth=false");
        parameters.Add("client_secret", "...");
        parameters.Add("code", code);
        result = fb.Get("/oauth/access_token", parameters);
        string accessToken = result["access_token"];
        // use token in next requests, insert status to session state 
        // & inject close window JS script - simple: window.close();
    }
