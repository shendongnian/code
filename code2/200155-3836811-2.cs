      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
      webRequest.AllowAutoRedirect = false;  // IMPORTANT
      webRequest.UserAgent = ...;
      webRequest.Timeout = 10000;           // timeout 10s
    
      // Get the response ...
      using (webResponse = (HttpWebResponse)webRequest.GetResponse())
      {   
         // Now look to see if it's a redirect
         if ((int)webResponse.StatusCode >= 300 && (int)webResponse.StatusCode <= 399)
         {
           string uriString = webResponse.Headers["Location"];
           Console.WriteLine("Redirect to " + uriString ?? "NULL");
           ...
         }
      }
