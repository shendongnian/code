    var dte2 = (DTE2)application;
    var projects = (Projects)dte2.ActiveSolutionProjects;
    foreach (Project project in projects)
    {
        Console.Out.WriteLine(project.Name);
        ProcessProject(project);
    }
