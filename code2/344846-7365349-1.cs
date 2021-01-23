    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    
    request.UserAgent = _UserAgent;
    request.CookieContainer = cookies;  // optional
    
    using (WebResponse response = request.GetResponse())
    {
      using (Stream responseStream = response.GetResponseStream())
      {
        using (StreamReader reader = new StreamReader(responseStream))
        {
          html = reader.ReadToEnd();
        }
      }
    }
