    SplashWindow window = null;
    var thread = new Thread(new ThreadStart(() =>
    {
        Debug.Print("Thread begin");
        window = new SplashWindow();
        window.ShowDialog();
    }));
    thread.Name = "RunSplashWindow";
    thread.SetApartmentState(ApartmentState.STA);
    thread.IsBackground = true;
    thread.Start();
    Debug.Print("App begin");
    
    Thread.Sleep(1000);
    
    if (window != null)
    {
        window.Dispatcher.BeginInvoke(new Del(() => {
            window.SetHeader("Running...");
        }), new object[0]);
    }
    
    Thread.Sleep(1000);
    for (int i = 1; i <= 100; i++)
    {
        if (window != null)
            {
                 window.Dispatcher.BeginInvoke(new Del(() =>
                 {
                 window.SetProgress((double)i);
            }), new object[0]);
        }
    
        Thread.Sleep(10);
    }
    Thread.Sleep(1000);
    
    Debug.Print("App end");
    
    if (window != null)
    {
        window.Dispatcher.BeginInvoke(new Del(() =>
        {
            window.Close();
        }), new object[0]);
    }
