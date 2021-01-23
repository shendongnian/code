	catch (WebException ex)
	{
		HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
		Stream dataStream = webResponse.GetResponseStream();
		if (dataStream != null)
		{
			StreamReader reader = new StreamReader(dataStream);
			response = reader.ReadToEnd();
		}
	}
