	private static async Task<string> downloadsource(string link)
	{
		ServicePointManager.Expect100Continue = false;
		WebRequest req = WebRequest.Create(link);
		req.Proxy = null;
		req.Method = "GET";
		using (WebResponse res = await req.GetResponseAsync())
		{
			using (StreamReader read = new StreamReader(res.GetResponseStream()))
			{
				return read.ReadToEnd();
			}
		}
	}
