    public static string FileDownload(string _ip, int _port, string _file, int Timeout, int ReadWriteTimeout, NetworkCredential _cred = null)
    {
        string uri = String.Format("http://{0}:{1}/{2}", _ip, _port, _file);
        string Data = String.Empty;
		try
		{
			HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(uri);
			if (_cred != null) Request.Credentials = _cred;
			Request.Timeout = Timeout; // applies to .GetResponse()
			Request.ReadWriteTimeout = ReadWriteTimeout; // applies to .GetResponseStream()
			Request.Proxy = null;
			Request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
			using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
			{
				using (Stream dataStream = Response.GetResponseStream())
				{
					if (dataStream != null)
						using (BufferedStream buffer = new BufferedStream(dataStream))
						using (StreamReader reader = new StreamReader(buffer))
						{
							Data = reader.ReadToEnd();
						}
				}
				return Data;
			}
		}
		catch (AccessViolationException ave)
		{
			// ...
		}
		catch (Exception exc)
		{
			// ...
		}
    }
