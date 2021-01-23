    System.Net.ServicePointManager.Expect100Continue = false;
    System.Net.CookieContainer cookies = new System.Net.CookieContainer();
    
    // this first request just ensures we have a session cookie, if one exists
    System.Net.WebRequest req = System.Net.WebRequest.Create("http://localhost/test.aspx");
    ((System.Net.HttpWebRequest)req).CookieContainer = cookies;
    System.Net.WebResponse resp = req.GetResponse();
       
    // this request submits the data to the server
    req = System.Net.WebRequest.Create("http://localhost/test.aspx");
    req.ContentType = "application/x-www-form-urlencoded";
    req.Method = "POST";
    ((System.Net.HttpWebRequest)req).CookieContainer = cookies;
    
    string parms = string.Format("email={0}&password={1}", 
        System.Web.HttpUtility.UrlEncode("e2@email.com"), System.Web.HttpUtility.UrlEncode("hunter2"));
    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(parms);
    req.ContentLength = bytes.Length;
    
    // perform the POST
    using (System.IO.Stream os = req.GetRequestStream()) 
    {
       os.Write(bytes, 0, bytes.Length);
    }
    
    // read the response
    string response;
    using (resp = req.GetResponse())
    {
      if (resp == null) return;
      using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
      {
          response = sr.ReadToEnd().Trim();
      }
    }
    // the variable response holds the results of the request...
