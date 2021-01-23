    var version = Assembly.GetExecutingAssembly().GetName().Version;
    
    long newVersion = version.Major * 1000000000L + 
                       version.Minor * 1000000L + 
                       version.Build * 1000L + 
                       version.Revision;
