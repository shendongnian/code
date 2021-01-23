        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
		void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			if (!e.IsTerminating)
			{
				MainWindow mw = GetRefToTheMainWindowSomehow();
				mw.AppendException(e.ExceptionObject);
			}
		}
