    using (HostingEnvironment.Impersonate())
    {
       var domainContext = new PrincipalContext(ContextType.Domain, "myDomain.com");
       var groupPrincipal = GroupPrincipal.FindByIdentity(domainContext, IdentityType.Name, "PowerUsers");
       if (groupPrincipal != null)
       {
          //code to get the infomation
       }
    
    }
