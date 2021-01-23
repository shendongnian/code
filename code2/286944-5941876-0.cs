    // Set up the CRM Service.
    var token = new CrmAuthenticationToken();
    token.AuthenticationType = 0; 
    token.OrganizationName = "{yourorgname}";
 
    var service = new CrmService();
    service.Url = "http://<servername>:<port>/mscrmservices/2007/crmservice.asmx";
    service.CrmAuthenticationTokenValue = token;
    service.Credentials = System.Net.CredentialCache.DefaultCredentials;
