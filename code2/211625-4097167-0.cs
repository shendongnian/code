    using (WebClient client = new WebClient())
    {
    	using (Stream rawStream = client.OpenRead(url))
    	{
    		string fileName = string.Empty;
    		string contentDisposition = client.ResponseHeaders["content-disposition"];
    		if (!string.IsNullOrEmpty(contentDisposition))
    		{
    			string lookFor = "filename=";
    			int index = contentDisposition.IndexOf(lookFor, StringComparison.CurrentCultureIgnoreCase);
    			if (index >= 0)
    				fileName = contentDisposition.Substring(index + lookFor.Length);
    		}
    		if (fileName.Length > 0)
    		{
    			using (StreamReader reader = new StreamReader(rawStream))
    			{
    				File.WriteAllText(Server.MapPath(fileName), reader.ReadToEnd());
    				reader.Close();
    			}
    		}
    		rawStream.Close();
    	}
    }
