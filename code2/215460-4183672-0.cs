    void Installer1_AfterInstall(object sender, InstallEventArgs e)
    {
        var thread = new Thread(new ThreadStart(DisplayFormThread));
        thread.Start();
        thread.Join();
    }
    [STAThread]
    private void DisplayFormThread()
    {
        try
        {
            MainWindow ObjMain = new MainWindow();
            ObjMain.Show();
        }
        catch (Exception ex)
        {
            Log.Write(ex);
        }
    }
