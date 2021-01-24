    try
     {
     ClientCredentials clientCredentials = new ClientCredentials();
     clientCredentials.UserName.UserName = "<ProvideUserName>@<ProvideYourOrgName>.onmicrosoft.com";
     clientCredentials.UserName.Password = "<ProvideYourPassword>";
    
    // For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    // Get the URL from CRM, Navigate to Settings -> Customizations -> Developer Resources
    // Copy and Paste Organization Service Endpoint Address URL
    organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri("https://<ProvideYourOrgName>.api.<CRMRegion>.dynamics.com/XRMServices/2011/Organization.svc"),
     null, clientCredentials, null);
    
    if (organizationService != null)
     {
     Guid userid = ((WhoAmIResponse)organizationService.Execute(new WhoAmIRequest())).UserId;
    
    if (userid != Guid.Empty)
     {
     Console.WriteLine("Connection Established Successfully...");
     // your logic here.
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
                qe.EntityName = "contact";
                qe.ColumnSet= new ColumnSet(true); // this will give you all the columns of contact record
    			//qe.ColumnSet= new ColumnSet("name", "accountnumber"); you could also restrict which particualr attributes you wish to retrieve from contact record.
    
                EntityCollection coll = organizationService.RetrieveMultiple(qe);
                foreach (Entity cont in coll.Entities)
                {
                    Console.WriteLine("Name of contact: " + cont.GetAttributeValue<string>("fullname"));
                    Console.WriteLine("Email of contact " + cont.GetAttributeValue<string>("email"));
    				/**
    				Now you can add all the attributes you wish to show
    				*/
                }
    
            }
