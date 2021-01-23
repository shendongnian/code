    String scriptContent = // get script content
    Logger logger = new Logger();
    Logger2 logger2 = new Logger2();
    // create ps runspace
    using (Runspace runspace = RunspaceFactory.CreateRunspace())
    {
    	// start session
        runspace.Open();
    	// set variables
        runspace.SessionStateProxy.SetVariable("logger", logger);
    	// supply commands
        using (Pipeline pipeline = runspace.CreatePipeline())
        {
    		// create ps representation of the script
            Command script = new Command(scriptContent, true, false);
            // suppy parameters to the script
    		script.Parameters.Add(new CommandParameter("logger2", logger2));
    		// send script to pipeline
            pipeline.Commands.Add(script);
            // execute it
            Collection<PSObject> results = pipeline.Invoke();
    		// close runspace
            runspace.Close();
        }
    }
