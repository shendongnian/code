    get
    {
        if(this._oRootConfig == null)
            this._oRootConfig = (System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath));
        return this._oRootConfig;
    }
