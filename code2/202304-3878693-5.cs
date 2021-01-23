	void DoSpeedTestDownloadFromFCC()
	{
	
	string strMyUrl = "http://data.fcc.gov/api/speedtest/find?latitude=38.0&longitude=-77.5&format=json";
		//create the request
		var wr = (HttpWebRequest)WebRequest.Create(strMyUrl);
		wr.ContentLength = strPostData.Length;
                //Note that I changed the method for the webservice's standard.
                //No Content type on GET requests.
		wr.Method = "GET";
		//just for good measure, set cookies if necessary for session management, etc.
		wr.CookieContainer = new CookieContainer();
	
		var resp = wr.GetResponse();
	
		//...
		using(StreamReader sr = new StreamReader(resp.GetResponseStream()))
		{
                        //here you would write the file to disk using your preferred method
                        //in linq pad, this just outputs the text to the console.
			sr.ReadToEnd().Dump();
		}
	
	}
