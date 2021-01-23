	{
		string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
		uploadRequest = (HttpWebRequest)WebRequest.Create(@"https://graph.facebook.com/me/photos");
		uploadRequest.ServicePoint.Expect100Continue = false;
		uploadRequest.Method = "POST";
		uploadRequest.UserAgent = "Mozilla/4.0 (compatible; Windows NT)";
		uploadRequest.ContentType = "multipart/form-data; boundary=" + boundary;
		uploadRequest.KeepAlive = false;
		StringBuilder sb = new StringBuilder();
		string formdataTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n";
		sb.AppendFormat(formdataTemplate, boundary, "access_token", PercentEncode(facebookAccessToken));
		sb.AppendFormat(formdataTemplate, boundary, "message", PercentEncode("This is an image"));
		string headerTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n";
		sb.AppendFormat(headerTemplate, boundary, "source", "file.png", @"application/octet-stream");
		string formString = sb.ToString();
		byte[] formBytes = Encoding.UTF8.GetBytes(formString);
		byte[] trailingBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
		long imageLength = imageMemoryStream.Length;
		long contentLength = formBytes.Length + imageLength + trailingBytes.Length;
		uploadRequest.ContentLength = contentLength;
		uploadRequest.AllowWriteStreamBuffering = false;
		Stream strm_out = uploadRequest.GetRequestStream();
		strm_out.Write(formBytes, 0, formBytes.Length);
		byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)imageLength))];
		int bytesRead = 0;
		int bytesTotal = 0;
		imageMemoryStream.Seek(0, SeekOrigin.Begin);
		while ((bytesRead = imageMemoryStream.Read(buffer, 0, buffer.Length)) != 0)
		{
			strm_out.Write(buffer, 0, bytesRead); bytesTotal += bytesRead;
			gui.OnUploadProgress(this, (int)(bytesTotal * 100 / imageLength));
		}
		strm_out.Write(trailingBytes, 0, trailingBytes.Length);
		strm_out.Close();
		HttpWebResponse wresp = uploadRequest.GetResponse() as HttpWebResponse;
	}
