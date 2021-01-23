    public string HttpGetByWebRequ(string uri, string username, string password)
    {
	//For Basic Authentication
        string authInfo = username + ":" + password;
        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
	
	//For Proxy
        WebProxy proxy = new WebProxy("http://10.127.0.1:8080", true);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.Method = "GET";
        request.Accept = "application/json; charset=utf-8";
        request.Proxy = proxy;
        
        request.Headers["Authorization"] = "Basic " + authInfo;
        
        var response = (HttpWebResponse)request.GetResponse();
        
        string strResponse = "";
        using (var sr = new StreamReader(response.GetResponseStream()))
        {
            strResponse= sr.ReadToEnd();
        }
        return strResponse;
    }
