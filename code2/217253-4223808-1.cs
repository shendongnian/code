    private static Process PrepareTfProcess(string args)
    {
        return new Process
                          {
                              StartInfo =
                                  {
                                      CreateNoWindow = true,
                                      FileName = @"consoleapp.exe",
                                      Arguments = args,
                                      RedirectStandardOutput = true,
                                      UseShellExecute = false
                                  }
                          };
        
    }
 
    //...
    using (var process = PrepareTfProcess("--param1 --param2"))
    {
        while (!process.StandardOutput.EndOfStream)
        {
            string str = process.StandardOutput.ReadLine();
            // Process output lines here
        }
    }
    //...
