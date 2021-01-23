    public void ExecuteExternalCommand(string command)
    {
     try
     {
      // process start info
      System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
      processStartInfo.RedirectStandardOutput = true;
      processStartInfo.UseShellExecute = false;
      processStartInfo.CreateNoWindow = true; // Don't show console
    
      // create the process
      System.Diagnostics.Process process = new System.Diagnostics.Process();
      process.StartInfo = processStartInfo;
      process.Start();
        
      string output = process.StandardOutput.ReadToEnd();
      Console.WriteLine(output);
     }
     catch (Exception exception)
     {
      //TODO: something Meaninful
     }
    }
 
