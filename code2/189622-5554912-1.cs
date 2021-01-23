    private void RunSql(string serverName, string databaseName, string userName = null, string password = null)
    {
        SanitizeString(ref userName);
        SanitizeString(ref password);
        // The `MsTest` assert - works in both `Debug` and `Release` modes.
        Assert.AreEqual<string>(
            userName == String.Empty,
            password == String.Empty,
            "User name and password should be either both empty or both non-empty!");
       
       var cmdBuilder = new StringBuilder();
       cmdBuilder.AppendFormat("sqlcmd -E -S {0} -d {1} ", serverName, databaseName);
       if (userName.Length > 0)
       {
           cmdBuilder.AppendFormat("-U {0} -P {1} ", userName, password);
       }
       
       // Complete the command string.
       // Run the executable.
    }
    private void SanitizeString(ref source)
    {
        if (String.IsNullOrWhiteSpace(source))
        {
            source = String.Empty;
        }
    }
