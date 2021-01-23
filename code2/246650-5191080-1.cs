    dynamic apps = new DynamicAppSettings();
    apps.UploadLocation = "~/Uploads/";
    apps.WebServiceUrl = "http://www.site.com/service.svc";
    apps.Remove("Trash");
    apps.Save();
    dynamic conns = new DynamicConnectionStrings();
    conns.CoreBanking = "Data Source=lpc:(local);Integrated Security=True;Initial Catalog=master";
    conns.Save();
