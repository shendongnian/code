    if (null != AppDomain.CurrentDomain.ActivationContext)
    {
        DeployManifest manifest;
        using (MemoryStream stream = new MemoryStream(AppDomain.CurrentDomain.ActivationContext.DeploymentManifestBytes))
        {
            manifest = (DeployManifest)ManifestReader.ReadManifest("Deployment", stream, true);
        }
        // manifest.Product has the name you want
    }
    else
    {
       // not deployed
    }
