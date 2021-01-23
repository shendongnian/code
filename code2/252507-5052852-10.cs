    static string GetWebResponse(string url, NameValueCollection parameters)
    {
      var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
      httpWebRequest.Method = "POST";
      var sb = new StringBuilder();
      foreach (var key in parameters.AllKeys)
        sb.Append(key + "=" + parameters[key] + "&");
      sb.Length = sb.Length - 1;
      byte[] requestBytes = Encoding.UTF8.GetBytes(sb.ToString());
      httpWebRequest.ContentLength = requestBytes.Length;
      using (var requestStream = httpWebRequest.GetRequestStream())
      {
        requestStream.Write(requestBytes, 0, requestBytes.Length);
        requestStream.Close();
      }
      Task<WebResponse> responseTask = Task.Factory.FromAsync<WebResponse>(httpWebRequest.BeginGetResponse, httpWebRequest.EndGetResponse, null);
      using (var responseStream = responseTask.Result.GetResponseStream())
      {
        var reader = new StreamReader(responseStream);
        return reader.ReadToEnd();
      }
    }
