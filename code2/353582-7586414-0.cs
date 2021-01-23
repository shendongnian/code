     public void StartProcess()
    {
     p.StartInfo.FileName = BasePath;
     p.StartInfo.Arguments = args;
     p.Start();
     p.Exited += new EventHandler(Process_Exited);
    }
    void Process_Exited(object sender, EventArgs e)
    {
    var p = sender as Process;
    if (p.ExitCode != 0)
        MessageBox.Show(string.Format("Process failed: ExitCode = {0}", p.ExitCode));
    }
