	public string HttpFileGetReq(Uri uri, int reqTimeout, Encoding encoding)
	{
		string stringResponse;
		var req = (HttpWebRequest)WebRequest.Create(uri);
		req.Timeout = reqTimeout;
		var res = (HttpWebResponse)req.GetResponse();
		using (var receiveStream = res.GetResponseStream())
		{
		    using (var readStream = new StreamReader(receiveStream,encoding))
		    {
		        return readStream.ReadToEnd();
		    }
		}
	}
