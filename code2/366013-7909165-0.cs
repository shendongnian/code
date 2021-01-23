	public string void decryptContainer(string dlc_content) //why not return a string, let caller decide what to do with it.
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dcrypt.it/decrypt/paste");
		request.Method = "POST";
		request.ContentType = "application/x-www-form-urlencoded";
		request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";//sure this is needed? Maybe just match the one content-type you expect.
		using (StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
		{
			writer.Write("content=" + Uri.EscapeDataString(dlc_content));//escape the value of dlc_content so that the entity sent is valid application/x-www-form-urlencoded
		}
		using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())//this should be disposed when finished with.
		using (StreamReader reader = new StreamReader(response.GetResponseStream()))
		{
			return reader.ReadToEnd();
		}
	}
