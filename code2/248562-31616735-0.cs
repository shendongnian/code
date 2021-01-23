    public string GetSolutionDirectory()
    {
        var serviceProvider = this.Host as IServiceProvider;
        var dte = serviceProvider.GetService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
        return System.IO.Path.GetDirectoryName(dte.Solution.FullName);
    }
