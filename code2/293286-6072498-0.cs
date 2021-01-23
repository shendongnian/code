    Process p = new Process();
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.RedirectStandardInput = true;
    p.StartInfo.CreateNoWindow = true;
    
    p.StartInfo.FileName = "C:/windows/system32/cmd.exe";
    p.StartInfo.Arguments = "/c dir" ;
    p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
    bool f = p.Start();
    p.BeginOutputReadLine();
    p.WaitForExit();
    
    [...]
    static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
    	Console.WriteLine(e.Data);
    }
