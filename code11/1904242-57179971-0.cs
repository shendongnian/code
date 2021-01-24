    static void ExecuteCommand(string command)
    {
        int exitCode;
        ProcessStartInfo processInfo;
        Process process;
        processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
        processInfo.CreateNoWindow = true;
        processInfo.Domain = "domain"; // Your own domain
        processInfo.UserName = "userName"; // Your own user name
        System.Security.SecureString s = new System.Security.SecureString();
        s.AppendChar('p'); // Your own password
        s.AppendChar('a');
        s.AppendChar('s');
        s.AppendChar('s');
        s.AppendChar('w');
        s.AppendChar('o');
        s.AppendChar('r');
        s.AppendChar('d');
        processInfo.Password = s;
        processInfo.UseShellExecute = false;
        // *** Redirect the output ***
        processInfo.RedirectStandardError = true;
        processInfo.RedirectStandardOutput = true;
        process = Process.Start(processInfo);
        process.WaitForExit();
        // *** Read the streams ***
        // Warning: This approach can lead to deadlocks, see Edit #2
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        exitCode = process.ExitCode;
        Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : 
     output));
        Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : 
     error));
        Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
        process.Close();
    }
    static void Main()
    {
        ExecuteCommand(@"C:\displayMsg.bat");
    }   
