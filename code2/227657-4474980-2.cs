		/// <summary>
		/// Create a new HttpWebRequest with the default properties for HTTP POSTS
		/// </summary>
		/// <param name="url">The URL to be posted to</param>
		/// <param name="referer">The refer</param>
		/// <param name="cookies">CookieContainer that should be used in this request</param>
		/// <param name="postData">The post data (needs to be formatted in name=value& format</param>
		private string CreateHttpWebPostRequest(string url, string referer, CookieContainer cookies, NameValueCollection postData)
		{
			var sbPostData = new StringBuilder();
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
								sbPostData.Append(string.Format("{0}={1}&", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)));
						}
					}
				}
			}
			var parameterString = Encoding.UTF8.GetBytes(sbPostData.ToString());
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
			request.Method = WebRequestMethods.Http.Post;
			request.CookieContainer = cookies;
			request.ContentLength = parameterString.Length;
			request.ContentType = "application/x-www-form-urlencoded";
			request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.55 Safari/533.4";
			request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, */*";
			request.Headers.Add("Accept-Encoding: gzip,deflate");
			request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
			request.Headers.Add("Accept-Language: en-us");
			request.Referer = referer;
			request.KeepAlive = true;
			request.AllowAutoRedirect = false;
			using (Stream requestStream = request.GetRequestStream())
			{
				requestStream.Write(parameterString, 0, parameterString.Length);
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
