    SshClient sshClient = new SshClient("some IP", 22, "loign", "pwd");
    sshClient.Connect();
    
    ShellStream shellStream = sshClient.CreateShellStream("xterm", 80, 40, 80, 40, 1024);
                
    string cmd = "ls";
    shellStream.WriteLine(cmd + "; echo !");
    while (shellStream.Length == 0)
     Thread.Sleep(500);
                
    StringBuilder result = new StringBuilder();
    string line;
    
    string dbt = @"PuttyTest.txt";
    StreamWriter sw = new StreamWriter(dbt, append: true);           
    
     while ((line = shellStream.ReadLine()) != "!")
     {
      result.AppendLine(line);
      sw.WriteLine(line);
     }            
    
     sw.Close();
     sshClient.Disconnect();
     sshClient.Dispose();
     Console.ReadKey();
