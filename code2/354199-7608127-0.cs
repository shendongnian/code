    public static void IncreaseMaxReceivedMessageSize ()
    {
        SPWebService contentService = SPWebService.ContentService;
    
        /* Must set this to -1, else, the MaxReceivedMessageSize value for
        SPWebService.ContentService.WcfServiceSettings["client.svc"] will not be used.*/
        contentService.ClientRequestServiceSettings.MaxReceivedMessageSize = -1;
    
        // SPWcfServiceSettings has other Properties that you can set.
        SPWcfServiceSettings csomWcfSettings = new SPWcfServiceSettings();
        csomWcfSettings.MaxReceivedMessageSize = 10485760; // 10MB
        contentService.WcfServiceSettings["client.svc"] = csomWcfSettings;
    
        contentService.Update();
    }
