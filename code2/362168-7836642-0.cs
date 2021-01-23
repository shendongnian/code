	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
	request.Timeout = 5000;
	request.ReadWriteTimeout = 5000;
	request.Proxy = new WebProxy("http://" + proxyUsed + "/", true);
	request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.01; Windows NT 5.0)";//ahem! :)
	DateTime giveUp = DateTime.UtcNow.AddSeconds(5); 
	using (WebResponse myResponse = request.GetResponse())
	{                    
		httpLink = myResponse.ResponseUri.AbsoluteUri;
		using (Stream s = myResponse.GetResponseStream())
		{
			s.ReadTimeout = 5000;
			s.WriteTimeout = 5000;
			char[] buffer = new char[4096];
			StringBuilder sb = new StringBuilder()
			using (StreamReader sr = new StreamReader(s, System.Text.Encoding.UTF8))
			{                            
				for(int read = sr.Read(buffer, 0, 4096); read != 0; read = sr.Read(buffer, 0, 4096))
				{
					if(DateTime.UtcNow > giveUp)
						throw new TimeoutException();
					sb.Append(buffer, 0, read);
				}
				result = sb.ToString();
			}
		}
	}
