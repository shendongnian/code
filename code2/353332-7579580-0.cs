    string[] lines = System.IO.File.ReadAllLines(@"my_file_with_urls.txt");
    
    // make URIs and eliminates possible duplicates
    var urisToProcess = new HashSet<Uri>(lines.ConvertAll(s => new Uri(s)));
    
    // all URIs that where redirected
    var redirectedUris = new HashSet<Uri>();
    foreach (var uri in urisToProcess)
    {
      Uri response;    
      WebSiteIsAvailable(uri, out response); 
      if(response.Equals(uri))
      {
        // do work on the actual URI
        continue;
      }
      // redirection could also happen within the same host
      // and multiple redirects are possible
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
      // do work on redirected URIs
    }
