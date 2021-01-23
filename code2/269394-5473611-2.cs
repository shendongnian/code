    public static ApplicationDeployment CurrentDeployment
    {
       ...
       get
       {
          ActivationContext activationContext = AppDomain.CurrentDomain.ActivationContext;
          ...
          fullName = activationContext.Identity.FullName;
          if (string.IsNullOrEmpty(fullName))
          {
             throw new InvalidDeploymentException(Resources.GetString("Ex_AppIdNotSet"));
          }
