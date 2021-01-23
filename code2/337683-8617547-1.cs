    protected void Page_Load(object sender, EventArgs e)
    {
        _accessToken = (AccessToken)Session["AccessTokken"];
        string _customerkey = "my customer key";
        string _customerSecret = "my customer secret key";
        string nostring = "";
        string nnString = "";
        OAuthBase oauth = new OAuthBase();
        //Twitter
        Uri t = new Uri("http://api.twitter.com/1/statuses/home_timeline.xml");
        string u = oauth.GenerateSignature(t, _customerkey, _customerSecret, _accessToken.Token,
                                           _accessToken.TokenSecret, "GET", oauth.GenerateTimeStamp(),
                                           oauth.GenerateNonce(), out nostring, out nnString);
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(nostring);
        request.Method = "GET";
        
        string realm = Request.Url.Scheme + "://" + Request.Url.DnsSafeHost + Request.ApplicationPath;
        OAuthUtils util = new OAuthUtils();
        AuthorizeHeader h = util.GetUserInfoAuthorizationHeader(t.ToString(), realm, _customerkey, _customerSecret,
                                                   _accessToken.Token, _accessToken.TokenSecret,
                                                   SignatureMethod.HMACSHA1, "GET");
        request.Headers.Add("Authorization",h.ToString());
        Response.Write(request.Headers["Authorization"].ToString() + "<br />");
        try
        {
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            reader.Close();
            Response.Write(responseString);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            //throw;
        }
    }
  
