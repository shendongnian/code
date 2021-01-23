    var inPlaceHostingManager = new InPlaceHostingManager(ApplicationDeployment.CurrentDeployment.UpdateLocation, false);
    inPlaceHostingManager.GetManifestCompleted += ((sender, e) =>
    {
        try
        {
            var deploymentDescription = new DeploymentDescription(e.DeploymentManifest);
            string productName = deploymentDescription.Product;
            ***DoSomethingToYour(productName);***
            // - use this later - 
            //var commandBuilder = new StartMenuCommandBuilder(deploymentDescription);
            //string startMenuCommand = commandBuilder.Command;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
        }
    });
