    var beforeCulture = Thread.CurrentThread.CurrentCulture;
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    
    using (var session = new EventLogSession(ipOrAddress, userDomain, username, password, SessionAuthentication.Default))
    {
      var query = new EventLogQuery("System", PathType.LogName, queryString)
        {
          ReverseDirection = true,
          Session = session
        };
      
      using (var reader = new EventLogReader(query))
      {
        for (var record = reader.ReadEvent(); record != null; record = reader.ReadEvent())
        {
          // Read event records
          string message = record.FormatDescription();
        }
      }
    }
    
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
