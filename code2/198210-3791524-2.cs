    private DTE2 dte2;
    public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
    {
        dte2 = (DTE2)application;
        var events = (Events2)dte2.Events;
        solutionEvents = events.SolutionEvents;
        solutionEvents.Opened += OnSolutionOpened;
    }
    private void OnSolutionOpened()
    {
    	Projects projects = dte2.Solution.Projects;
        foreach (Project project in projects)
        {
            ProcessProject(project);
        }
    }
    private void ProcessProject(Project project)
    {
        string directoryName = Path.GetDirectoryName(project.FileName);
        string fileName = Path.GetFileName(project.FileName);
        if (directoryName == null || fileName == null)
    	{
	        return;
    	}
        var directory = new DirectoryInfo(directoryName);
    	var fileInfo = new FileInfo(fileName);
        //do work
    }
