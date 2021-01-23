    Thread thread = new Thread(() =>
    {
     Window1 w = new Window1();
     w.Show();
     //make sure to stop the Dispatcher when window is closed
     w.Closed += (s, e) => w.Dispatcher.InvokeShutdown();
     //start the message pump
     System.Windows.Threading.Dispatcher.Run();
    });
    
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
