    void Installer1_AfterInstall(object sender, InstallEventArgs e)
    {
        var thread = new Thread(new ThreadStart(DisplayFormThread));
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
    }
    private void DisplayFormThread()
    {
        try
        {
            MainWindow ObjMain = new MainWindow();
            ObjMain.Show();
            ObjMain.Closed += (s, e) => System.Windows.Threading.Dispatcher.ExitAllFrames();
            System.Windows.Threading.Dispatcher.Run();
        }
        catch (Exception ex)
        {
            Log.Write(ex);
        }
    }
