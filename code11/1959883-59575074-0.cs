    string siteUrl = "https://tenant.sharepoint.com/sites/team";
    string userName = "test@tenant.onmicrosoft.com";
    string password = "xxx";
    string searchQuery = "/_api/search/query?querytext='documentname IsDocument:True'";
    
    var securePassword = new SecureString();
    foreach (char c in password.ToCharArray()) securePassword.AppendChar(c);
    
    var credential = new SharePointOnlineCredentials(userName, securePassword);
    HttpClientHandler handler = new HttpClientHandler() { Credentials = credential };
    
    Uri uri = new Uri(siteUrl);
    handler.CookieContainer.SetCookies(uri, credential.GetAuthenticationCookie(uri));
    
    HttpClient client = new HttpClient(handler);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
    client.DefaultRequestHeaders.Add("ContentType", "application/json;odata=verbose");
    
    var result = client.GetAsync(siteUrl + searchQuery).Result;
    var content = result.Content.ReadAsStringAsync().Result;
    JObject jobj = JObject.Parse(content);
    JArray jarr = (JArray)jobj["d"]["query"]["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"]["results"];
    foreach (JObject j in jarr)
    {
    	JArray results = (JArray)j["Cells"]["results"];
    	var title = "";
    	var path = "";
    	foreach (JObject r in results)
    	{
    		if (r["Key"] != null)
    		{
    			if (r["Key"].ToString() == "Title")
    			{
    				title = r["Value"].ToString();
    			}
    			if (r["Key"].ToString() == "Path")
    			{
    				path = r["Value"].ToString();
    			}
    		}
    	}
    	Console.WriteLine(title + "|" + path);
    }
    Console.ReadKey();  
