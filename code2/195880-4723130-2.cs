    public void execute(string workingDirectory, string command)
    {   
        // create the ProcessStartInfo using "cmd" as the program to be run, and "/c " as the parameters.
        // Incidentally, /c tells cmd that we want it to execute the command that follows, and then exit.
        System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo(workingDirectory + "\\" + "my.bat ", command);
       
        procStartInfo.WorkingDirectory = workingDirectory;
    
        //This means that it will be redirected to the Process.StandardOutput StreamReader.
        procStartInfo.RedirectStandardOutput = true;
        //This means that it will be redirected to the Process.StandardError StreamReader. (same as StdOutput)
        procStartInfo.RedirectStandardError = true;
    
        procStartInfo.UseShellExecute = false;
        // Do not create the black window.
        procStartInfo.CreateNoWindow = true;
        // Now we create a process, assign its ProcessStartInfo and start it
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
    
        //This is importend, else some Events will not fire!
         proc.EnableRaisingEvents = true;
    
        // passing the Startinfo to the process
        proc.StartInfo = procStartInfo;
         
        // The given Funktion will be raised if the Process wants to print an output to consol                    
        proc.OutputDataReceived += DoSomething;
        // Std Error
        proc.ErrorDataReceived += DoSomethingHorrible;
        // If Batch File is finished this Event will be raised
        proc.Exited += Exited;
    }
