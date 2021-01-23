	class Program
	{
		static void Main(string[] args)
		{
			string test = Get("http://www.google.co.uk/search?q=test&ie=utf-8&oe=utf-8&aq=t&rls=org.mozilla:en-GB:official&client=firefox-a");
			Console.Read();
		}
		public static string Get(string url)
		{
			Uri requestedUri = new Uri(url);
			string fulladdress = requestedUri.Host;
			IPHostEntry entry = Dns.GetHostEntry(fulladdress);
			StringBuilder sb = new StringBuilder();
			try
			{
				using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP))
				{
					socket.Connect(entry.AddressList[0], 80);
					NetworkStream ns = new NetworkStream(socket);
					string part_request = string.Empty;
					string build_request = string.Empty;
					if (jar.Count != 0)
					{
						part_request = "GET {0} HTTP/1.1\r\nHost: {1} \r\nUser-Agent: Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.13) Gecko/20101203 Firefox/3.6.13\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8\r\nAccept-Language: en-us,en;q=0.5\r\nAccept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7\r\nCookie: {2}\r\nConnection: keep-alive\r\n\r\n";
						build_request = string.Format(part_request, requestedUri.PathAndQuery, requestedUri.Host, GetCookies(requestedUri));
					}
					else
					{
						part_request = "GET {0} HTTP/1.1\r\nHost: {1} \r\nUser-Agent: Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.13) Gecko/20101203 Firefox/3.6.13\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8\r\nAccept-Language: en-us,en;q=0.5\r\nAccept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7\r\nConnection: keep-alive\r\n\r\n";
						build_request = string.Format(part_request, requestedUri.PathAndQuery, requestedUri.Host);
					}
					byte[] data = Encoding.UTF8.GetBytes(build_request);
					socket.Send(data, data.Length, 0);
					byte[] bytesReceived = new byte[4096];
					int bytes = 0;
					string currentBatch = "";
					do
					{
						bytes = socket.Receive(bytesReceived);
						currentBatch = Encoding.ASCII.GetString(bytesReceived, 0, bytes);
						Console.Write(currentBatch);
						sb.Append(currentBatch);
					}
					while (bytes == bytesReceived.Length);
					List<String> CookieHeaders = new List<string>();
					foreach (string header in sb.ToString().Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
					{
						if (header.StartsWith("Set-Cookie"))
						{
							CookieHeaders.Add(header.Replace("Set-Cookie: ", ""));
						}
					}
					//this.AddCookies(CookieHeaders, requestedUri);
					socket.Close();
				}
			}
			catch (Exception ex)
			{
				string errorMessage = ex.Message;
			}
			return sb.ToString();
		}
		static CookieContainer jar = new CookieContainer();
		public static string GetCookies(Uri _uri)
		{
			StringBuilder sb = new StringBuilder();
			CookieCollection collection = jar.GetCookies(_uri);
			if (collection.Count != 0)
			{
				foreach (Cookie item in collection)
				{
					sb.Append(item.Name + "=" + item.Value + ";");
				}
			}
			return sb.ToString();
		}
    	}
    }
