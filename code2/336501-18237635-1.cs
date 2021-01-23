			try
		{
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("client_id", "638ed32066b04801bd40aa05c1542915");
			parameters.Add("client_secret", "fc67cf3645a648ce82106298010acd65");
			parameters.Add("grant_type", "authorization_code");
			parameters.Add("redirect_uri", "http://localhost:34962/Test/InstagramCallback");
			parameters.Add("code", code);
			WebClient client = new WebClient();
			var result = client.UploadValues("https://api.instagram.com/oauth/access_token", "POST", parameters);
			return Encoding.Default.GetString(result);
		}
		catch (WebException ex)
		{
			StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
			string line;
			StringBuilder result = new StringBuilder();
			while ((line = reader.ReadLine()) != null)
			{
				result.Append(line);
			}
			return result.ToString();
		}
