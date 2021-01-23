    public void WebRequestinJson(Method method, string url, string postData)
    		{
			StreamWriter requestWriter;
			
			var webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
			if (webRequest != null)
			{
				webRequest.Method = method.ToString();
				webRequest.ServicePoint.Expect100Continue = false;
				webRequest.Timeout = 20000;
				if (method == Method.Post)
				{
					webRequest.ContentType = "application/json";
					//POST the data.
					requestWriter = new StreamWriter(webRequest.GetRequestStream());
					try
					{
						requestWriter.Write(postData);
					}
					finally
					{
						requestWriter.Close();
					}
				}
				
			}
		}
