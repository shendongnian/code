    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TargetPlatform
    {
        get
        {
            if (!DesignMode)
                return null;
            var host = (IDesignerHost)Site.GetService(typeof(IDesignerHost));
            var dte = (EnvDTE.DTE)host.GetService(typeof(EnvDTE.DTE));
            var project = dte.ActiveSolutionProjects[0];
            return project.ConfigurationManager.ActiveConfiguration.Properties
                          .Item("PlatformTarget").Value;
        }
    }
