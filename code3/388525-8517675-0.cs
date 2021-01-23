      string url = @"http://localhost/WebApp/AddService.asmx/Add";
      string postData = "x=6&y=8";
    
      WebRequest req = WebRequest.Create(url);
      HttpWebRequest httpReq = (HttpWebRequest)req;
    
      httpReq.Method = WebRequestMethods.Http.Post;
      httpReq.ContentType = "application/x-www-form-urlencoded";
      Stream s = httpReq.GetRequestStream();
      StreamWriter sw = new StreamWriter(s,Encoding.ASCII);
      sw.Write(postData);
      sw.Close();
    
      HttpWebResponse httpResp = 
                     (HttpWebResponse)httpReq.GetResponse();
      s = httpResp.GetResponseStream();
      StreamReader sr = new StreamReader(s, Encoding.ASCII);
      Console.WriteLine(sr.ReadToEnd());
