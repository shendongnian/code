    static void Main(string[] args)
            {
                IOrganizationService organizationService = null;    
                try
                {
                    ClientCredentials clientCredentials = new ClientCredentials();
                    clientCredentials.UserName.UserName = "AdminCRM@dabc.onmicrosoft.com";
                    clientCredentials.UserName.Password = "pwd";
    
                    //For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    //Get the URL from CRM, Navigate to Settings -> Customizations -> Developer Resources
                    //Copy and Paste Organization Service Endpoint Address URL
                    
                    organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri("https:/[OrgUrl]/XRMServices/2011/Organization.svc"),
                        null, clientCredentials, null);
    
                    if (organizationService != null)
                    {
                        Guid userid = ((WhoAmIResponse)organizationService.Execute(new WhoAmIRequest())).UserId;
    
                        if (userid != Guid.Empty)
                        {
                            Console.WriteLine("Connection Established Successfully...");                          
                        FetchXmlTestQuery(organizationService);
                        queryExpressionTest(organizationService);    
    
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to Established Connection!!!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught - " + ex.Message);
                }
                Console.ReadKey();    
    
            }
     private static void queryExpressionTest(IOrganizationService organizationService)
            {
                QueryExpression qe = new QueryExpression();
                qe.EntityName = "account";
                qe.ColumnSet= new ColumnSet("name", "accountnumber");
    
                EntityCollection coll = organizationService.RetrieveMultiple(qe);
                foreach (Entity acunt in coll.Entities)
                {
                    Console.WriteLine("Name of Account: " + acunt.GetAttributeValue<string>("name"));
                    Console.WriteLine("Number of Account: " + acunt.GetAttributeValue<string>("accountnumber"));
                }
    
            }
    
    
    private static void FetchXmlTestQuery(IOrganizationService CrmConn)
            {
                // Retrieve all accounts owned by the user with read access rights to the accounts and   
                // where the last name of the user is not Cannon.   
                string fetch = @"  
       <fetch>
      <entity name='account' >
        <attribute name='name' />
    <attribute name='accountnumber' />
        <link-entity name='contact' from='parentcustomerid' to='accountid' link-type='inner' alias='Contact' >
          <attribute name='fullname' alias = 'Contact.Fullname' />
        </link-entity>
      </entity>
    </fetch> ";
    
               EntityCollection Coll = CrmConn.RetrieveMultiple(new FetchExpression(fetch));
    
                    foreach (Entity acunt in Coll.Entities)
                    {
                        Console.WriteLine("Name of Account: " + acunt.GetAttributeValue<string>("name"));
                        Console.WriteLine("Name of Contact: "  + acunt.GetAttributeValue<AliasedValue>("Contact.Fullname").Value);
                        Console.WriteLine("Number of Account: " + acunt.GetAttributeValue<string>("accountnumber"));
                }
    
                  
            }
