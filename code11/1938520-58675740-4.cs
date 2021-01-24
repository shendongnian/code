    // Nuget :
    // https://www.nuget.org/packages/Microsoft.Build.Locator
    // https://www.nuget.org/packages/Microsoft.CodeAnalysis.Workspaces.MSBuild/
    // https://www.nuget.org/packages/Microsoft.CodeAnalysis
    
	if (!MSBuildLocator.IsRegistered)
	{
		MSBuildLocator.RegisterDefaults();
	}
	using(var wp = MSBuildWorkspace.Create()){
		var project = await wp.OpenProjectAsync(@"pathtocsprojfile.csproj");
		Console.WriteLine(project.CompilationOptions.OutputKind);
	}
