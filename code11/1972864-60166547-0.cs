	//Declare Webrequest
    HttpWebRequest re = null;
	re = (HttpWebRequest)WebRequest.Create(url);
	try
	{
		var response = (HttpWebResponse)re.GetResponse();
		System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{response.StatusCode}");
	}
	catch (WebException e)
	{
		var errorResponse = (HttpWebResponse)e.Response;
		System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{errorResponse.StatusCode}");
	}
