    static void Main(string[] args)
    {
      const string SHELL_URI = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";
      const string COMMAND = @"get-process | format-List | Out-File -file c:\temp\jpb.txt";
      System.Uri serverUri = new Uri("http://WM2008R2ENT/powershell?serializationLevel=Full");
      PSCredential creds = (PSCredential)null; // Use Windows Authentication
      WSManConnectionInfo connectionInfo = new WSManConnectionInfo(false,
                                                                   "WM2008R2ENT",
                                                                   5985,
                                                                   "/wsman",
                                                                   SHELL_URI,
                                                                   creds);
      try
      {
        using (Runspace rs = RunspaceFactory.CreateRunspace(connectionInfo))
        {
          rs.Open();
    
          Pipeline pipeline = rs.CreatePipeline();
    
          string cmdLine;
          cmdLine = string.Format("&{{{0}}}", COMMAND);
    
          pipeline.Commands.AddScript(cmdLine);
    
          Collection<PSObject> results = pipeline.Invoke();
    
          rs.Close();
        }
      }
      catch (Exception ex)
      {
        System.Console.WriteLine("exception: {0}", ex.ToString());
      }
      return; 
    }
