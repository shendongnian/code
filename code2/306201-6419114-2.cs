    SiteData.SiteDataSoapClient siteDataService = new SiteData.SiteDataSoapClient();
    siteDataService.Endpoint.Address = new System.ServiceModel.EndpointAddress("URL/_vti_bin/sitedata.asmx");
    siteDataService.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential("username", "password", "domain");
    siteDataService.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
    
    String xmlInput = "<GetChanges>" + 
    				  "<ObjectType>7</ObjectType>" + 
    				  "<ContentDatabaseId>{X5C5E20A-5A9F-406C-B9F6-28923750CECD}</ContentDatabaseId>" + 
    				  "<StartChangeId>1;1;69b025ce-96a7-4131-adc0-7da1603e8d24;634439727021700000;47404</StartChangeId>" + 
    				  "<EndChangeId>1;1;69b025ce-96a7-4131-adc0-7da1603e8d24;634441802456970000;47472</EndChangeId>" + 
    				  "<RequestLoad>100</RequestLoad>" + 
    				  "<GetMetadata>False</GetMetadata>" + 
    				  "<IgnoreSecurityIfInherit>True</IgnoreSecurityIfInherit>" + 
    				  "</GetChanges>";
    String result = siteDataService.GetChangesEx(1, xmlInput);
