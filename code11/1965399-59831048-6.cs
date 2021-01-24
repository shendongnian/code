    private void Run(StartupEventArgs e)
    {
      IMainViewModel viewModel = container.GetExportedValue<IMainViewModel>();
    
      // For simplicity, you can add the view model to the globally accessible App.xaml ResourceDictionary
      this.Resources.Add("MainViewModel", viewModel);
    
      var mainWindow = new MainWindow { DataContext = viewModel };
      mainWindow.Show();
    }
