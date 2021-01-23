    private string ExternalServicesUrl
    {
      get
      {
        string externalServiceUrl = ConfigurationManager.AppSettings["ExternalServicesUrl"];
        if (String.IsNullOrEmpty(externalServiceUrl))
          throw new MissingConfigFileAppSettings("The Config file is missing the appSettings entry for: ExternalServicesUrl");
        return externalServiceUrl;
      }
    }
