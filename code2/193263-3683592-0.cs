    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);
      // Create the ViewModel to attach the window to
      MainWindow window = new MainWindow();
      var viewModel = new MainWindowViewModel();
    
      // Create the handler that will allow the window to close when the viewModel asks.
      EventHandler handler = null;
      handler = delegate
      {
        //***Code here to decide on closing the application****
        //***returns resultClose which is true if we want to close***
        if(resultClose == true)
        {
          viewModel.RequestClose -= handler;
          window.Close();
        }
      }
      viewModel.RequestClose += handler;
    
      window.DataContaxt = viewModel;
    
      window.Show();
    
    }
