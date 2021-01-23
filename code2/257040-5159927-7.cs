		private void HandleStartup(object sender, StartupEventArgs e)
		{
			var container = CreateContainer(); // create IoC container
 		   var mainViewModel = container.Resolve<MainViewModel>();
			var shell = new Shell { DataContext = mainViewModel }; // main View
			MainWindow = shell;
			shell.Show();
		}
