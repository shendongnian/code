        //Modifications at MoonLight's IsolatedStorageSettings.cs to make it work with WPF (whether deployed via ClickOnce or not):
    // per application, per-computer, per-user
    public static IsolatedStorageSettings ApplicationSettings {
      get {
        if (application_settings == null) {
          application_settings = new IsolatedStorageSettings (
            (System.Threading.Thread.GetDomain().ActivationContext!=null)?
              IsolatedStorageFile.GetUserStoreForApplication() : //for WPF, apps deployed via ClickOnce will have a non-null ActivationContext
              IsolatedStorageFile.GetUserStoreForAssembly());
        }
        return application_settings;
      }
    }
    // per domain, per-computer, per-user
    public static IsolatedStorageSettings SiteSettings {
      get {
        if (site_settings == null) {
          site_settings = new IsolatedStorageSettings (
            (System.Threading.Thread.GetDomain().ActivationContext!=null)?
              IsolatedStorageFile.GetUserStoreForApplication() : //for WPF, apps deployed via ClickOnce will have a non-null ActivationContext
              IsolatedStorageFile.GetUserStoreForAssembly());
              //IsolatedStorageFile.GetUserStoreForSite() works only for Silverlight applications
        }
        return site_settings;
      }
    }
