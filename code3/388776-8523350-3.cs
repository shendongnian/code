    IServiceProvider serviceProvider = this.Host as IServiceProvider;
    DTE dte = serviceProvider.GetService(typeof(DTE)) as DTE;
    object[] activeSolutionProjects = dte.ActiveSolutionProjects as object[];
    
    if(activeSolutionProjects != null)
    {
    	Project project = activeSolutionProjects[0] as Project;
    	if(project != null)
    	{
    		Properties projectProperties = project.Properties;
    		Properties configurationProperties = project.ConfigurationManager.ActiveConfiguration.Properties;
    		string projectDirectory = Path.GetDirectoryName(project.FullName);	
    		string outputPath = configurationProperties.Item("OutputPath").Value.ToString();
    		string outputFile = projectProperties.Item("OutputFileName").Value.ToString();
    		
    		string outDir = Path.Combine(projectDirectory, outputPath);
    		string targetPath = Path.Combine(outDir, outputFile);
    	}
    }
