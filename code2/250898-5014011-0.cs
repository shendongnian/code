    public static bool IsConnected()
    {
      HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("http://www.google.com");
    
      HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
      bool isconnected = (HttpWResp.StatusCode == HttpStatusCode.OK);
      HttpWResp.Close();
      return isconnected;
    }
