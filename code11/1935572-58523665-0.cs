    if (xdoc.Root.Descendants("HOST").Descendants("Default").Any())
    {
        if (xdoc.Root.Descendants("HOST").Descendants("Default").FirstOrDefault().Descendants("HostID").FirstOrDefault().Descendants("Deployment").Any())
        {
            if (xdoc.Root.Descendants("HOST").Descendants("Default").FirstOrDefault().Descendants("HostID").Any())
            {
                var hopsTempplateDeployment = xdoc.Root.Descendants("HOST").Descendants("Default").FirstOrDefault().Descendants("HostID").FirstOrDefault().Descendants("Deployment").FirstOrDefault();
                deploymentKind = hopsTempplateDeployment.Attribute("DeploymentKind");
                host = hopsTempplateDeployment.Attribute("HostName");
            }
        }
    }
