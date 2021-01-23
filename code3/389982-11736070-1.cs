    // System.Net.WebClient
    private byte[] UploadValuesInternal(NameValueCollection data)
    {
    	if (this.m_headers == null)
    	{
    		this.m_headers = new WebHeaderCollection(WebHeaderCollectionType.WebRequest);
    	}
    	string text = this.m_headers["Content-Type"];
    	if (text != null && string.Compare(text, "application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase) != 0)
    	{
    		throw new WebException(SR.GetString("net_webclient_ContentType"));
    	}
    	this.m_headers["Content-Type"] = "application/x-www-form-urlencoded";
    	string value = string.Empty;
    	StringBuilder stringBuilder = new StringBuilder();
    	string[] allKeys = data.AllKeys;
    	for (int i = 0; i < allKeys.Length; i++)
    	{
    		string text2 = allKeys[i];
    		stringBuilder.Append(value);
    		stringBuilder.Append(WebClient.UrlEncode(text2));
    		stringBuilder.Append("=");
    		stringBuilder.Append(WebClient.UrlEncode(data[text2]));
    		value = "&";
    	}
    	byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
    	this.m_ContentLength = (long)bytes.Length;
    	return bytes;
    }
