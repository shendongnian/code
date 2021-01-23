    SPSecurity.RunWithElevatedPrivileges(delegate(){
    SPSite site = new SPSite(siteUrl); //You need the url here
   
       using(SPWeb web = site.OpenWeb();
       {
          web.Title = "The new Title";
          web.Update();
       }
    });
