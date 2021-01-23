	var request = WebRequest.CreateHttp(url);
	request.Credentials = new NetworkCredential(username, password);
	request.CookieContainer = new CookieContainer(); // needed to enable cookies
	
	using (var response = (HttpWebResponse)request.GetResponse())
	using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet)))
		return string.Format("Server response:\n{0}\n{1}", response.StatusDescription, reader.ReadToEnd());
  
  
