    IServiceProvider hostServiceProvider = (IServiceProvider)Host;
    // see @GarethJ's answer for the following
    DTE2 dte2 = GetCOMService(hostServiceProvider, typeof(EnvDTE.DTE)) as DTE2;
    object dteObject1 = GetCOMService(hostServiceProvider, typeof(EnvDTE.DTE));
    EnvDTE80.DTE2 dte2 = (EnvDTE80.DTE2)dteObject1;
    var solExplorer = dte2.ToolWindows.SolutionExplorer;  
    solExplorer.Parent.Activate();
    ProjectItem containingProjectItem = dte2.Solution.FindProjectItem(templateFile);
    Project project = containingProjectItem.ContainingProject;
    UIHierarchy solExplorerHierarchy = solExplorer.Parent.Object as UIHierarchy;
    string projectSolutionPath = Path.Combine(dte2.Solution.Properties.Item("Name").Value.ToString(), project.Name);
    var projectItem = solExplorerHierarchy.GetItem(projectSolutionPath);
    projectItem.Select(vsUISelectionType.vsUISelectionTypeSelect);
    dte2.ExecuteCommand("Project.UnloadProject", ""); 
    dte2.ExecuteCommand("Project.ReloadProject", "");
