    private static string Get(string uri)
     {
       string returnStr  = trsing.Empty;
      try
       {    
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.Timeout=10;
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream ?? throw new 
        InvalidOperationException());
        returnStr  = reader.ReadToEnd();
     }
     catch( Exception ex)
     {
      Debug.Writeline( ex.ToString());
     }
    
     return returnStr  ;
    }
