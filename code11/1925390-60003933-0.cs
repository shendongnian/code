    private const string TenantID = "[Your Tenant ID]";
    private const string ClientID = "[Your Client ID]";
    private const string ClientSecret = "[Your Secret ID]";
    
    private const string AgentName = "My Agent Name";
    
    public static ExchangeService OAuthConnectPost()
    {
    	string LoginURL = String.Format("https://login.microsoftonline.com/{0}/oauth2/v2.0/token", TenantID);
    
    	var LogValues = new Dictionary<string, string>
    	{
    		{ "grant_type", "client_credentials" },
    		{ "client_id", ClientID },
    		{ "client_secret", ClientSecret },
    		{ "scope", "https://graph.microsoft.com/.default" }
    	};
    	string postData = "";
    	foreach (var v in LogValues)
    	{
    		postData += (String.IsNullOrWhiteSpace(postData) ? "" : "&") + v.Key + "=" + v.Value;
    	}
    	var data = Encoding.ASCII.GetBytes(postData);
    
    	ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    	ServicePointManager.Expect100Continue = true;
    	ServicePointManager.DefaultConnectionLimit = 9999;
    	ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
    	   | SecurityProtocolType.Tls11
    	   | SecurityProtocolType.Tls12
    	   | SecurityProtocolType.Ssl3;
    
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(LoginURL);
    	request.Method = "POST";
    	request.ContentType = "application/x-www-form-urlencoded";
    	request.Accept = "*/*";
    	request.UserAgent = AgentName;
    	request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
    	request.ContentLength = data.Length;
    	using (var stream = request.GetRequestStream())
    	{
    		stream.Write(data, 0, data.Length);
    	}
    
    	using (var response = (HttpWebResponse)request.GetResponse())
    	using (Stream stream = response.GetResponseStream())
    	using (var reader = new StreamReader(stream))
    	{
    		var json = reader.ReadToEnd();
    		var aToken = JObject.Parse(json)["access_token"].ToString();
    
    		var ewsClient = new ExchangeService();
    		ewsClient.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
    		ewsClient.Credentials = new OAuthCredentials(aToken);
    		return ewsClient;
    	}
    }
