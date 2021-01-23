            string command = @"Output.exe"; 
      string arguments = "hellotext"; 
 
      ProcessStartInfo info = new ProcessStartInfo(command, arguments); 
 
      // Redirect the standard output of the process.  
      info.RedirectStandardOutput = true; 
      info.RedirectStandardError = true; 
 
      // Set UseShellExecute to false for redirection 
      info.UseShellExecute = false; 
 
      Process proc = new Process(); 
      proc.StartInfo = info; 
      proc.EnableRaisingEvents = true; 
 
      // Set our event handler to asynchronously read the sort output. 
      proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutputDataReceived); 
      proc.ErrorDataReceived += new DataReceivedEventHandler(proc_ErrorDataReceived); 
      proc.Exited += new EventHandler(proc_Exited); 
 
      proc.Start(); 
      // Start the asynchronous read of the sort output stream. Note this line! 
      proc.BeginOutputReadLine(); 
      proc.BeginErrorReadLine(); 
 
      proc.WaitForExit(); 
 
      Console.WriteLine("Exited (Main)"); 
 
    } 
 
    static void proc_Exited(object sender, EventArgs e) 
    { 
 
      Console.WriteLine("Exited (Event)"); 
    } 
 
 
 
    static void proc_ErrorDataReceived(object sender, DataReceivedEventArgs e) 
    { 
      Console.WriteLine("Error: {0}", e.Data); 
    } 
 
 
 
    static void proc_OutputDataReceived(object sender, DataReceivedEventArgs e) 
    { 
      Console.WriteLine("Output data: {0}", e.Data); 
    } 
 
