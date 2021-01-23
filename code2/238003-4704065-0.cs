    public Method1(string user, string password) {
      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseurl);
      
      req.Method = "POST";
      req.ContentType = "application/x-www-form-urlencoded";
      string login = string.Format("go=&Fuser={0}&Fpass={1}", user, password);
      byte[] postbuf = Encoding.ASCII.GetBytes(login);
      req.ContentLength = postbuf.Length;
      Stream rs = req.GetRequestStream();
      rs.Write(postbuf,0,postbuf.Length);
      rs.Close();
      cookie = req.CookieContainer = new CookieContainer();
      WebResponse resp = req.GetResponse();
      resp.Close();
    }
