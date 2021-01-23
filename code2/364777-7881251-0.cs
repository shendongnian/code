        var request = (HttpWebRequest)WebRequest.Create( "http://www.extremetech.com/feed" );
        request.IfModifiedSince = lastModified; 
        try {
          using ( var response = (HttpWebResponse)request.GetResponse() ) {
            lastModified  = response.LastModified;
            using ( var stream = response.GetResponseStream() ) {
              //*** parsing the stream
              var reader = XmlReader.Create( stream );
              SyndicationFeed feed = SyndicationFeed.Load( reader );
              }
            }
          }
        catch ( WebException e ) {
          var response = (HttpWebResponse)e.Response;
          if ( response.StatusCode != HttpStatusCode.NotModified )
            throw; // rethrow an unexpected web exception
          }
