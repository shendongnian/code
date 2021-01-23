    static void Main(string[] args)
    {
        ProcessStartInfo psi = new ProcessStartInfo("echoApp.exe");
        psi.RedirectStandardInput = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
        psi.UseShellExecute = false;
                
        Process echoApp = new Process();
        echoApp.ErrorDataReceived += new DataReceivedEventHandler(echoApp_ErrorDataReceived);
        echoApp.OutputDataReceived += new DataReceivedEventHandler(echoApp_OutputDataReceived);
        echoApp.StartInfo = psi;
        echoApp.Start();
        echoApp.BeginOutputReadLine();
        echoApp.BeginErrorReadLine();
        echoApp.StandardInput.AutoFlush = true;
                
        string str = "";
        while (str != "end")
        {
            str = Console.ReadLine();
            echoApp.StandardInput.WriteLine(str);
        }
        echoApp.CancelOutputRead();
        echoApp.CancelErrorRead();
        echoApp.Close();
    }
    
    static void echoApp_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine("stdout: {0}", e.Data);
    }
    
    static void echoApp_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine("stderr: {0}", e.Data);
    }
