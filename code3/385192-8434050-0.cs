	private string SubmitRequest(string url, Dictionary<string, string> parms)
	{
		var req = WebRequest.Create(url);
		req.Method = "POST";
		string parmsString = string.Join("&", parms.Select(p => string.Format("{0}={1}", p.Key, p.Value)));
		req.ContentLength = parmsString.Length;
		using (StreamWriter writer = new StreamWriter(req.GetRequestStream()))
		{
			writer.Write(parmsString);
			writer.Close();
		}
		var res = req.GetResponse();
		using (StreamReader reader = new StreamReader(res.GetResponseStream()))
		{
			string response = reader.ReadToEnd();
			reader.Close();
			return response;
		}
	}
