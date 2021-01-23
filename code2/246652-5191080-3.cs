    dynamic apps = new DynamicAppSettings();
    apps.UploadLocation = "~/Uploads/";
    apps.WebServiceUrl = "http://www.site.com/service.svc";
    apps.Remove("TempFolderPath");
    apps.Save();
    dynamic conns = new DynamicConnectionStrings();
    conns.MasterDatabase = "Data Source=lpc:(local);Integrated Security=True;Initial Catalog=master";
    conns.Save();
