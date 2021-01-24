    protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
            {
                if (localContext == null)
                {
                    throw new ArgumentNullException("localContext");
                }
    
                // TODO: Implement your custom plug-in business logic.
                IPluginExecutionContext context = localContext.PluginExecutionContext;
                ITracingService tracingService = localContext.TracingService;
                IOrganizationService orgService = localContext.OrganizationService;
    
                FetchXmlTestQuery(orgService);
                queryExpressionTest(orgService);
    }
    
     private void FetchXmlTestQuery(IOrganizationService orgService)
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
    
                EntityCollection Coll = orgService.RetrieveMultiple(new FetchExpression(fetch));
    
                foreach (Entity acunt in Coll.Entities)
                {
                  string accountname= acunt.GetAttributeValue<string>("name");
                 string accountnr=  acunt.GetAttributeValue<string>("accountnumber");
                }
            }
            private static void queryExpressionTest(IOrganizationService organizationService)
            {
                QueryExpression qe = new QueryExpression();
                qe.EntityName = "account";
                qe.ColumnSet = new ColumnSet("name", "accountnumber");
    
                EntityCollection coll = organizationService.RetrieveMultiple(qe);
                foreach (Entity acunt in coll.Entities)
                {
                    string accountname = acunt.GetAttributeValue<string>("name");
                    string accountnr =  acunt.GetAttributeValue<string>("accountnumber");
                }
    
            }
