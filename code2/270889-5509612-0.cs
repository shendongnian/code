    HttpWebRequest req;
    HttpWebResponse resp;
    
    req = (HttpWebRequest)WebRequest.Create("http://www.stackoverflow.com");
    resp = (HttpWebResponse)req.GetResponse();
    
    if(resp.StatusCode.ToString().Equals("OK"))
    {
          Console.WriteLine("its connected.");
    }
    else
    {
          Console.WriteLine("its not connected.");
    }
