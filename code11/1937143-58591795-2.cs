    public void LoadApp()
    {
        VisLoginLoading = Visibility.Visible;
    
        var thr = new Thread(() =>
        {
            var mw = new MainWindow();
            mw.Show();
            mw.Closed += (sender, e) => mw.Dispatcher.InvokeShutdown();
            System.Windows.Threading.Dispatcher.Run();
        });
        thr.SetApartmentState(ApartmentState.STA);
        thr.Start();
    
        //Move this logic to the MainWindow, after initialization is done.
        //foreach (Window window in Application.Current.Windows)
        //{
        //    if (window.Title == "Login") window.Close();
        //}
        VisLoginLoading = Visibility.Hidden;
    }
