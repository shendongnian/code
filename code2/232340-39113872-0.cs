    using System;
    using System.Deployment.Application;
    
    namespace Utils
    {
        public class ClickOnce
        {
            public static Version GetPublishedVersion()
            {
                return ApplicationDeployment.IsNetworkDeployed 
                    ? ApplicationDeployment.CurrentDeployment.CurrentVersion 
                    : System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
    }
