    var version = Assembly.GetExecutingAssembly().GetName().Version();
    
    long newVersion = version.Major * 100000000L + 
                       version.Minor * 1000000L + 
                       version.Build * 100L + 
                       version.Revision;
