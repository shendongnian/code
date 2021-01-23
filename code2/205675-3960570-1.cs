    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://whatismyipaddress.com/");
	request.Proxy = new WebProxy("110.139.166.78:8080");
	using (var req = request.GetResponse())
	{
		using (StreamReader reader = new StreamReader(req.GetResponseStream()))
		{
			Console.WriteLine(reader.ReadToEnd());
		}
	}
	Console.ReadLine();
