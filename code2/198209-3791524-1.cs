    var dte2 = (DTE2)application;
    Projects projects = dte2.Solution.Projects;
    foreach (Project project in projects)
    {
        Console.Out.WriteLine(project.Name);
        ProcessProject(project);
    }
