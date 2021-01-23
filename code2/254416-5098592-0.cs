    using (var serverManager = new ServerManager())
    {
        var siteName = HostingEnvironment.ApplicationHost.GetSiteName();
        var config = serverManager.GetWebConfiguration(siteName);
        var staticContentSection = config.GetSection("system.webServer/staticContent");
        var staticContentCollection = staticContentSection.GetCollection();
        var mimeMap = staticContentCollection.Where(c =>
            c.GetAttributeValue("fileExtension") != null &&
            c.GetAttributeValue("fileExtension").ToString() == ext
        ).Single();
        var mimeType = mimeMap.GetAttributeValue("mimeType").ToString();
        contentType = mimeType.Split(';')[0];
    }
