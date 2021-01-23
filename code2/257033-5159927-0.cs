		private void HandleStartup(object sender, StartupEventArgs e)
		{
			// Next line ensures that WPF will not ignore user OS culture settings
			FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            AutoMapperConfiguration.Configure();
			var container = CreateContainer(); // create IoC container
 		   var mainViewModel = container.Resolve<MainViewModel>();
			var shell = new Shell { DataContext = mainViewModel }; // main View
			MainWindow = shell;
			shell.Show();
		}
