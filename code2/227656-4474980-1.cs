		/// <summary>
		/// Create a new HttpWebRequest with the default properties for HTTP POSTS
		/// </summary>
		/// <param name="url">The URL to be posted to</param>
		/// <param name="referer">The refer</param>
		/// <param name="cookies">CookieContainer that should be used in this request</param>
		/// <param name="postData">The post data</param>
		private string CreateHttpWebUploadRequest(string url, string referer, CookieContainer cookies, NameValueCollection postData, FileInfo fileData, string fileContentType)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
			string boundary = "----------" + DateTime.UtcNow.Ticks.ToString("x", CultureInfo.InvariantCulture);
			// set the request variables
			request.Method = WebRequestMethods.Http.Post;
			request.ContentType = "multipart/form-data; boundary=" + boundary;
			request.CookieContainer = cookies;
			request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.55 Safari/533.4";
			request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, */*";
			request.Headers.Add("Accept-Encoding: gzip,deflate");
			request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
			request.Headers.Add("Accept-Language: en-us");
			request.Referer = referer;
			request.KeepAlive = true;
			request.AllowAutoRedirect = false;
			// process through the fields
			StringBuilder sbHeader = new StringBuilder();
			// add form fields, if any
			if (postData != null)
			{
				foreach (string key in postData.AllKeys)
				{
					string[] values = postData.GetValues(key);
					if (values != null) 
					{
						foreach (string value in values)
						{
							if (!string.IsNullOrEmpty(value))
								sbHeader.AppendFormat("--{0}\r\n", boundary);
								sbHeader.AppendFormat("Content-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}\r\n", key, value);
						}
					}
				}
			}
			if (fileData != null)
			{
				sbHeader.AppendFormat("--{0}\r\n", boundary);
				sbHeader.AppendFormat("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n", "media", fileData.Name);
				sbHeader.AppendFormat("Content-Type: {0}\r\n\r\n", fileContentType);
			}
			byte[] header = Encoding.UTF8.GetBytes(sbHeader.ToString());
			byte[] footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
			long contentLength = header.Length + (fileData != null ? fileData.Length : 0) + footer.Length;
			// set content length
			request.ContentLength = contentLength;
			using (Stream requestStream = request.GetRequestStream())
			{
				requestStream.Write(header, 0, header.Length);
				
				// write the uploaded file
				if (fileData != null)
				{
					// write the file data, if any
					byte[] buffer = new Byte[fileData.Length];
					var bytesRead = fileData.OpenRead().Read(buffer, 0, (int)(fileData.Length));
					requestStream.Write(buffer, 0, bytesRead);
				}
				// write footer
				requestStream.Write(footer, 0, footer.Length);
				requestStream.Flush();
				requestStream.Close();
				using (var response = request.GetResponse() as HttpWebResponse)
				{
					using (var stIn = new System.IO.StreamReader(response.GetResponseStream()))
					{
						return stIn.ReadToEnd();
					}
				}
			}
		}
