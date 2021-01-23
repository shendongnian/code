    var urisToProcess = new HashSet<Uri>(
      lines.Where(s => Uri.IsWellFormedUriString(s, UriKind.Absolute)).Select(s => new Uri(s)));
    var redirectedUris = new HashSet<Uri>();
    foreach (var uri in urisToProcess)
    {
      Uri response;    
      WebSiteIsAvailable(uri, out response); 
      if(response.Equals(uri))
      {
        // do work on actual URI
        continue;
      }
      while (!response.Equals(uri))
      {    
        uri = response;
        WebSiteIsAvailable(uri, out response); 
      }
      if(!urisToProcess.Contains(uri))
      {
         redirectedUris.Add(uri);
      }
    }
    foreach (var uri in redirectedUris)
    {
      // do work on redirected URI
    }
