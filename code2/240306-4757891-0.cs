    IEnumerable<Uri> uris = Browser.Links.Select(l => l.Uri);
    foreach(Uri uri in Uris)
    {
       try 
       {
          using(var browser = new IE(uri))
          {
              // do nothing or detect 404, 403, etc errors
          }
          
          // no error
       }
       catch(exception)
       {
          // log error
       }
    }
