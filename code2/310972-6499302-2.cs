    private string _ourVersion="Version: v";
    public string VersionNumber
    {
        get
        {
                
            System.Reflection.Assembly _assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();
    
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                _ourVersion += ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            else
            {
                if (_assemblyInfo != null)
                    _ourVersion += _assemblyInfo.GetName().Version.ToString();
            }
            return _ourVersion;
        }
    }
