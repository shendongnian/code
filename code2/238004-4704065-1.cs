    string GetPage(string path) {
      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
      req.CookieContainer = cookie;
      WebResponse resp = req.GetResponse();
      string t = new StreamReader(resp.GetResponseStream(), Encoding.Default).ReadToEnd();
      return IsoToWin1250(t);
    }
