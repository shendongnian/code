    string siteUrl = "http://sp2013/sites/team";
    string searchQuery = "/_api/search/query?querytext='IsDocument:True'";//search all documents
    var credential = new System.Net.NetworkCredential("username", "password", "domainname");
    
    HttpClientHandler handler = new HttpClientHandler() { Credentials = credential };
    
    
    HttpClient client = new HttpClient(handler);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
    client.DefaultRequestHeaders.Add("ContentType", "application/json;odata=verbose");
    
    var result = client.GetAsync(siteUrl+searchQuery).Result;
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
