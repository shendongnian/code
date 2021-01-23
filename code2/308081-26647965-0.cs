    public string GetAPIKey(OperationContext operationContext)
    {
        string apiKey = null;
        MessageHeaders headers = OperationContext.Current.RequestContext.RequestMessage.Headers;
        // Look at headers on incoming message.
        if (headers.FindHeader("apiKey","") > -1)
            apiKey = headers.GetHeader<string>(headers.FindHeader("apiKey",""));        
        // Return the API key (if present, null if not).
        return apiKey;
    }
