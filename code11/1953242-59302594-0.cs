	public void Upload(ICommandLineInfo info)
	{
		var webRequest = HttpWebRequest.Create(info.Url) as HttpWebRequest;
		const string HTTPBoundary = "AaB03x";
		webRequest.ContentType = "multipart/form-data;boundary=" + HTTPBoundary;
		const string HTTPHeaderCallingApplicationName = "ws-callingapplication";
		
		webRequest.Headers.Add(HTTPHeaderCallingApplicationName, info.CallingApplication);
		webRequest.KeepAlive = true;
		webRequest.UseDefaultCredentials = true;
		webRequest.PreAuthenticate = true;
		webRequest.Credentials = CredentialCache.DefaultCredentials;
		const string HTTPHeaderCacheControlName = "cache-control";
		const string HTTPHeaderValueCacheControlNo = "no-cache";
		webRequest.Headers.Add(HTTPHeaderCacheControlName, HTTPHeaderValueCacheControlNo);
		webRequest.Method = "POST";
		ADODB.Stream fileStream = new ADODB.Stream();
		fileStream.Type = ADODB.StreamTypeEnum.adTypeBinary;
		fileStream.Mode = ADODB.ConnectModeEnum.adModeReadWrite;
		fileStream.Open();
		fileStream.LoadFromFile(info.Filename);
		var byteData = fileStream.Read();
		fileStream.Close();
		ADODB.Stream mixedStream = new ADODB.Stream();
		mixedStream.Mode = ADODB.ConnectModeEnum.adModeReadWrite;
		mixedStream.Charset = "utf-8";
		mixedStream.Open();
		mixedStream.Type = ADODB.StreamTypeEnum.adTypeText;
		mixedStream.WriteText(Environment.NewLine + "--" + HTTPBoundary + Environment.NewLine + "Content-Disposition: form-data; name=\"itemName\"" + Environment.NewLine + Environment.NewLine + Path.GetFileName(info.Filename));
		mixedStream.WriteText(Environment.NewLine + "--" + HTTPBoundary + Environment.NewLine + "Content-Disposition: form-data; name=\"parentNickname\"" + Environment.NewLine + Environment.NewLine + info.ParentNickname);
		mixedStream.WriteText(Environment.NewLine + "--" + HTTPBoundary + Environment.NewLine + "Content-Disposition: form-data; name=\"file\"; filename=\"" + info.Filename + "\"" + Environment.NewLine);
		mixedStream.WriteText(Environment.NewLine);
		mixedStream.Position = 0;
		mixedStream.Type = ADODB.StreamTypeEnum.adTypeBinary;
		mixedStream.Position = mixedStream.Size;
		mixedStream.Write(byteData);
		byteData = null;
		mixedStream.Position = 0;
		mixedStream.Type = ADODB.StreamTypeEnum.adTypeText;
		mixedStream.Position = mixedStream.Size;
		mixedStream.WriteText(Environment.NewLine + Environment.NewLine + "--" + HTTPBoundary + "--" + Environment.NewLine);
		mixedStream.Position = 0;
		mixedStream.Type = ADODB.StreamTypeEnum.adTypeBinary;
		var read = mixedStream.Read();
		webRequest.ContentLength = read.Length;
		Stream requestStream = webRequest.GetRequestStream();
		requestStream.Write(read, 0, read.Length);
		requestStream.Close();
		try
		{
			var response = (HttpWebResponse)webRequest.GetResponse();
		}
		catch (WebException exception)
		{
			using (var reader = new System.IO.StreamReader(exception.Response.GetResponseStream()))
			{
				string responseText = reader.ReadToEnd();
			}
		}
	}
