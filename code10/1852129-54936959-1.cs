    protected string JSONQuery(string subPath, string query = null, string method = null, NameValueCollection extraHeaders = null, string body = null)
    {
      HttpWebRequest Request = PrepareHttpWebRequest(AuthenticationMethod.Basic, subPath, query, method, extraHeaders, body);
      using (WebResponse Response = Request.GetResponse())
      {
        using (Stream ResponseStream = Response.GetResponseStream())
        {
          using (StreamReader Reader = new StreamReader(ResponseStream, Encoding.UTF8))
          {
            string result = Reader.ReadToEnd();
            return result;
          }
        }
      }
    }
