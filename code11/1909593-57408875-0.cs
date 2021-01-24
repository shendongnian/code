        Runspace runspace = RunspaceFactory.CreateRunspace();
    	runspace.Open();
    	Collection<PSObject> configXML;
    
    	using (var pipeline = runspace.CreatePipeline())
    	{
    		pipeline.Commands.AddScript(
    			"(New-EapConfiguration -UseWinlogonCredential).EapConfigXmlStream");
    		configXML = pipeline.Invoke();
    	}
    	
    	using (var pipeline = runspace.CreatePipeline())
    	{
    		var cmd = new Command("Add-VpnConnection");
    		cmd.Parameters.Add(new CommandParameter(
    			"EapConfigXmlStream", configXML[0]));
    		pipeline.Commands.Add(cmd);
    		pipeline.Invoke();
    	}
