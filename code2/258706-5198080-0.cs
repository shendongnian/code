    public static string GetRequestPostData(HttpListenerRequest request)
    {
      if (!request.HasEntityBody)
      {
        return null;
      }
      using (System.IO.Stream body = request.InputStream) // here we have data
      {
        using (System.IO.StreamReader reader = new System.IO.StreamReader(body, request.ContentEncoding))
        {
          return reader.ReadToEnd();
        }
      }
    }
