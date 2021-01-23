    var proc = Process.Start("popup.exe");
    while (string.IsNullOrEmpty(proc.MainWindowTitle))
    {
        System.Threading.Thread.Sleep(100);
        proc.Refresh();
    }
