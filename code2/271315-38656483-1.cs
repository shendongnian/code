    using System.Diagnostics;
    public void ExecuteBatFile()
    {
        Process proc = null;
        string _batDir = string.Format(@"C:\");
        proc = new Process();
        proc.StartInfo.WorkingDirectory = _batDir;
        proc.StartInfo.FileName = "myfile.bat";
        proc.StartInfo.CreateNoWindow = false;
        proc.Start();
        proc.WaitForExit();
        ExitCode = proc.ExitCode;
        proc.Close();
        MessageBox.Show("Bat file executed...");
    }
