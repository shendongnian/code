    RestClient mRestClient = new RestClient();
    //mRestClient.BaseUrl = API_PRODUCTION_URL;
    mRestClient.BaseUrl = API_SANDBOX_URL;
    mRestClient.Authenticator = OAuth1Authenticator.ForRequestToken(API_KEY, 
                                                  API_SHAREDSECRET, 
                                                  "oob");
    RestRequest request = new RestRequest("oauth/request_token", Method.POST);
    request.AddParameter("scope", 
                         "shops_rw transactions_r transactions_w listings_r listings_w listings_d");
    RestResponse response = mRestClient.Execute(request);
    
    if (response.StatusCode != System.Net.HttpStatusCode.OK)
       return false;
                
    NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(response.Content);
    
    string oauth_token_secret = queryString["oauth_token_secret"];
    string oauth_token = queryString["oauth_token"];
    
    string url = queryString["login_url"];
    System.Diagnostics.Process.Start(url);
    
    // BREAKPOINT HERE
    string oauth_token_verifier = String.Empty; // get from URL
    
    request = new RestRequest("oauth/access_token");
    mRestClient.Authenticator = OAuth1Authenticator.ForAccessToken(API_KEY,
                               API_SHAREDSECRET,
                               oauth_token,
                               oauth_token_secret,
                               oauth_token_verifier);
    response = mRestClient.Execute(request);
    
    if (response.StatusCode != System.Net.HttpStatusCode.OK)
      return false;
    
    queryString = System.Web.HttpUtility.ParseQueryString(response.Content);
    
    string user_oauth_token = queryString["oauth_token"];
    string user_oauth_token_secret = queryString["oauth_token_secret"];
