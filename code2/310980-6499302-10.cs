    //using System.Deployment.Application;
    //using System.Reflection;
    public string CurrentVersion
    {
        get
        {
            return ApplicationDeployment.IsNetworkDeployed
                   ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                   : Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    } 
     
