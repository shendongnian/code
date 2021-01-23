    proc2 = Process.Start("HelpViewer.exe");
    proc2.Exited += new EventHandler(proc2_Exited);
    proc2.EnableRaisingEvents = true;
    void proc2_Exited(object sender, EventArgs e)
    {
        //Unregister the event and free the object resources
        _proc2.Exited -= new EventHandler(proc2_Exited);
        _proc2.Close();
        //Search and close the other process(es)
        Process[] processes = Process.GetProcessesByName("HelpViewer.exe");
        foreach(Process process in processes)
            process.CloseMainWindow();
    }
