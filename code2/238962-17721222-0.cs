    static class ProjectBuildSync
    {
    	private static readonly object _syncObject = new object();
    	public static bool Build(Project project)
    	{
    		lock (_syncObject)
    			return project.Build();
    	}
    }
    ...
    ProjectBuildSync.Build(project);
    ...
