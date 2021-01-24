    if (Test.Properties.Settings.Default.FirstRun)
    {
    	// Run tutorial
    	Test.Properties.Settings.Default.FirstRun = false;
    	Test.Properties.Settings.Default.Save();
    }
