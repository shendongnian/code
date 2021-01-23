    public static string HttpPost(string url, params object[] postData)
    {
    	StringBuilder post = new StringBuilder();
    	for (int i = 0; i < postData.Length; i += 2)
    		 post.Append(string.Format("{0}{1}={2}", i == 0 ? "" : "&", postData[i], postData[i + 1]));
    	return HttpPost(url, post.ToString());
    }
    public static string HttpPost(string url, string postData)
    {
    	postData = postData.Replace("\r\n", "");
    	try
    	{
    		 WebRequest req = WebRequest.Create(url);
    		 byte[] send = Encoding.Default.GetBytes(postData);
    		 req.Method = "POST";
    		 req.ContentType = "application/x-www-form-urlencoded";
    		 req.ContentLength = send.Length;
    
    		 Stream sout = req.GetRequestStream();
    		 sout.Write(send, 0, send.Length);
    		 sout.Flush();
    		 sout.Close();
    
    		 WebResponse res = req.GetResponse();
    		 StreamReader sr = new StreamReader(res.GetResponseStream());
    		 string returnvalue = sr.ReadToEnd();
    		 return returnvalue;
    	}
    	catch (Exception ex)
    	{
    		 Debug.WriteLine("POST Error on {0}\n  {1}", url, ex.Message);
    		 return "";
    	}
    }
