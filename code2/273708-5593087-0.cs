        private static void GetDeploymentEnvironment()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment dep = ApplicationDeployment.CurrentDeployment;
                FileInfo f = new FileInfo(dep.UpdateLocation.AbsolutePath + ".env");
                if (f.Exists)
                {
                    /// read file content and apply settings
                }
            }
        }
