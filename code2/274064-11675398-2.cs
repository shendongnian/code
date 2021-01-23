    public static string GetLocation(string ip)
	{
		var res = "";
		WebRequest request = WebRequest.Create("http://ipinfo.io/" + ip);
		using (WebResponse response = request.GetResponse())
		using (StreamReader stream = new StreamReader(response.GetResponseStream()))
		{
			string line;
			while ((line = stream.ReadLine()) != null)
			{
				res += line;
			}
		}
		return res;
	}
