               HttpClient.BaseAddress = new Uri(AppSettings.Dynamics365.WebAPI_ServiceRootURL);
               //Use the httpClient we setup with the Bearer token header           
               ODataClientSettings odataSettings = new ODataClientSettings(HttpClient, new Uri(WebAPI_VersionRelativeURL, UriKind.Relative))
               {
                   //Setting the MetadataDocument property prevent Simple.OData from making the expensive call to get the metadata
                   MetadataDocument = MetaDataDocumentAsString
               };
               _ODataClient = new ODataClient(odataSettings);
               HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken().Access_token);}
