    // perform the POST
    using (System.IO.Stream os = req.GetRequestStream()) 
    {
       os.Write(bytes, 0, bytes.Length);
    }
    
    // read the response
    string response;
    using (System.Net.WebResponse resp = req.GetResponse())
    {
      if (resp == null) return;
      using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
      {
          response = sr.ReadToEnd().Trim();
      }
    }
    // the variable response holds the results of the request...
