    var configuration = "Release";
    var projectDirectory = @"C:\blabla";
    var collection = ProjectCollection.GlobalProjectCollection;
    var project = collection.LoadProject($@"{projectDirectory}\MyProject.csproj");
    project.SetProperty("Configuration", configuration);
            
    project.Build();
