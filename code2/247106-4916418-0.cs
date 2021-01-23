    public void RunProcess()
    {
        Process process = new Process();
        process.StartInfo.FileName = "consoleApp.exe";
    
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
    
        for (; ; )
        {
            string line = process.StandardOutput.ReadLine();
            if (line == null)
                break;
    
            Dispatcher.Invoke(new Action(() =>
                {
                    textBlock1.Text += outLine.Data + Environment.NewLine;
                }), System.Windows.Threading.DispatcherPriority.Normal);
        }
        ...
    }
