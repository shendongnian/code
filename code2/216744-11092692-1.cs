    var browser = new WebBrowser();
    var brwhttp = typeof (WebRequestCreator).GetProperty("BrowserHttp");
    var requestFactory = brwhttp.GetValue(browser, null) as IWebRequestCreate;
    var uri = new Uri("https://www.login.com/login-handler");
    var req = requestFactory.Create(uri);
    req.Method = "POST";
    
    var postParams = new Dictionary<string, string> { 
        {"username", "turtlepower"}, 
        {"password": "ZoMgPaSSw0Rd1"}
    };
 
    req.BeginGetRequestStream(aReq => {
    
        var webRequest = (HttpWebRequest)aReq.AsyncState;
        using (var postStream = webRequest.EndGetRequestStream(aReq)) {
            // Build your POST request here
            var postDataBuilder = new StringBuilder();
            foreach (var pair in paramsDict) {
				if (postDataBuilder.Length != 0) {
					postDataBuilder.Append("&");
				}
				postDataBuilder.AppendFormat("{0}={1}", pair.Key, HttpUtility.UrlEncode(pair.Value));
			}
		    var bytes = Encoding.UTF8.GetBytes(postDataBuilder.ToString());
		    postStream.Write(bytes, 0, bytes.Length);
		}
	    // Receive response 
		webRequest.BeginGetResponse(aResp => {
	    
			var webRequest2 = (HttpWebRequest) aResp.AsyncState;
                    
			webRequest = (HttpWebRequest)aResp.AsyncState;
	    	string resp;
			using (var response = (HttpWebResponse)webRequest2.EndGetResponse(aResp)) {
				using (var streamResponse = response.GetResponseStream()) {
					using (var streamReader = new System.IO.StreamReader(streamResponse)) {
						resp = streamReader.ReadToEnd();
					}
				}
			}
		}, webRequest);
	}, req);
