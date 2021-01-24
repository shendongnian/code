    var priceList = new List<string>();
    var rx = new Regex("[$][0-9]{0,2},?[0-9]{3}");
    using (var client = new WebClient())
    {
        string body = client.DownloadString("example.com").Substring(140480,200000);
		var matches = rx.Matches(body);
		
		foreach (var match in matches)
		{
            priceList.Add(match);
		}	
    }
