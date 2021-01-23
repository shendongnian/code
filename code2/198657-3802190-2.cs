    try 
    {
      System.New.WebRequest.Create("http://www.google.com").GetResponse();
    }
    catch(WebException)
    {
      // Offline
    }
