	private AnApplicationContext()
	{
		Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
		// choose which form to show based on arguments
		if(Environment.GetCommandLineArgs().Contains("-apply"))
		{
			_currentForm = new ConfigurationApplierForm();
		}
		else
		{
			_currentForm = new ConfigurationActionManagerForm();
		}
		// initialize the form and attach event handlers
		_currentForm.FormClosed += new FormClosedEventHandler(this.OnCurrentFormClosed);
		_currentForm.ShowDialog();
	}
