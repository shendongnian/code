    public static void DeployWebsite(string user, string pw, string folder, string domain, string sitename)
            {
                DeploymentSyncOptions syncOptions = new DeploymentSyncOptions();
                DeploymentBaseOptions sourceBaseOptions = new DeploymentBaseOptions();
                DeploymentBaseOptions destinationBaseOptions = new DeploymentBaseOptions();
    
                destinationBaseOptions.ComputerName = domain;
                destinationBaseOptions.UserName = user;
                destinationBaseOptions.Password = pw;
    
                DeploymentObject deploymentObject = DeploymentManager.CreateObject(DeploymentWellKnownProvider.IisApp, folder, sourceBaseOptions);
                deploymentObject.SyncTo(DeploymentWellKnownProvider.IisApp, sitename, destinationBaseOptions, syncOptions);
            }
