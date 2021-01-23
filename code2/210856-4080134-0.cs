    using (Entities context = new Entities()){
      var webSites = from sites in context.AuditLogs.Include("SiteOwner")
                     where sites.WebSiteId == 1
                     select sites;
    }
