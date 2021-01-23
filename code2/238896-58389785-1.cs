	[STAThread]
	static void Main()
	{
        const string appName = "Name of your app";
		// Check number of instances running:
		// If more than 1 instance, cancel this one.
		// Additionally, if it is the 2nd invocation, show a message and exit.
		var numberOfAppInstances = Assembly.GetExecutingAssembly().HowManyTimesIsAssemblyRunning();
		if (numberOfAppInstances == 2)
		{
		   MessageBox.Show("The application is already running!
			+"\nClick OK to close this dialog, then switch to the application by using WIN + TAB keys.",
		    appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		};
		if (numberOfAppInstances >= 2)
		{
			return;
		};
    }
