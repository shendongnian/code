    public static string HttpPost(string url, object[] postData, string saveTo = "")
    {
    	StringBuilder post = new StringBuilder();
    	for (int i = 0; i < postData.Length; i += 2)
    		post.Append(string.Format("{0}{1}={2}", i == 0 ? "" : "&", postData[i], postData[i + 1]));
    	return HttpPost(url, post.ToString(), saveTo);
    }
    public static string HttpPost(string url, string postData, string saveTo = "")
    {
    	postData = postData.Replace("\r\n", "");
    	try
    	{
    		WebRequest req = WebRequest.Create(url);
    		byte[] send = Encoding.Default.GetBytes(postData);
    		req.Method = "POST";
    		req.ContentType = "application/x-www-form-urlencoded";
    		//req.ContentType = "text/xml;charset=\"utf-8\"";
    		req.ContentLength = send.Length;
    
    		Stream sout = req.GetRequestStream();
    		sout.Write(send, 0, send.Length);
    		sout.Flush();
    		sout.Close();
    
    		WebResponse res = req.GetResponse();
    		StreamReader sr = new StreamReader(res.GetResponseStream());
    		string returnvalue = sr.ReadToEnd();
    		if (!string.IsNullOrEmpty(saveTo))
    			File.WriteAllText(saveTo, returnvalue);
    
    		//Debug.WriteLine("{0}\n{1}", postData, returnvalue);
    		return returnvalue;
    	}
    	catch (Exception ex)
    	{
    		Debug.WriteLine("POST Error on {0}\n  {1}", url, ex.Message);
    		return "";
    	}
    }
    
