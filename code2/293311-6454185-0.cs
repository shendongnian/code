    public static IOrganizationService Service() 
    {
        ClientCredentials Credentials = new ClientCredentials(); 
        Credentials.Windows.ClientCredential.UserName ="<username>"; 
        Credentials.Windows.ClientCredential.Password ="<password>"; 
    
        //This URL needs to be updated to match the servername and Organization for the environment.
        Uri OrganizationUri = new Uri("http://<server name>/<organization name>/XRMServices/2011/Organization.svc"); 
        Uri HomeRealmUri = null; 
    
        //OrganizationServiceProxy serviceProxy; 
        using (OrganizationServiceProxy serviceProxy = new OrganizationServiceProxy(OrganizationUri, HomeRealmUri, Credentials, null)) 
        {
            IOrganizationService service = (IOrganizationService)serviceProxy; 
            return service; 
        }
    }
