c#
private void SetupPlugins(Container container, ILog log)
{ ...
    bool activeDirectoryAuthentication = ToBoolean(GlobalConfiguration.Instance.ActiveDirectoryAuthentication);
    ApplyTo applyTo = ApplyTo.Get;
    if (!activeDirectoryAuthentication) applyTo = ApplyTo.None;
    
    typeof(RequestA).AddAttributes(new AuthenticateAttribute(applyTo));
    typeof(RequestB).AddAttributes(new AuthenticateAttribute(applyTo));
    typeof(RequestC).AddAttributes(new AuthenticateAttribute(applyTo));
	...
 }
