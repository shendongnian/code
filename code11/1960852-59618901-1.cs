        var itemId = new Guid("fsdf78dsff-fsdgfg89g-fsgvssfdg89"); 
        var client = new ThirdPartyApiClient(apiBaseUri);
        client.SetBearerToken("Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IkI4QzE2QUNEOEYxODR"); 
        try
        {
            ApiResponse<Item> result = await client.GetItemAsync(itemId);
        }
        catch(HttpRequestException ex)
        {
            var innerEx = ex.InnerException;
            if( innerEx != null && innerEx is WebException )
            {
                // Check status value
                var webEx = innerEx as WebException;
                var webExStatus = webEx.Status;
                if( webExStatus ==  WebExceptionStatus.NameResolutionFailure )
                {
                    // This indicates a DNS resolution issue. You may need to use a proxy or fix the connection issue at this point.
                    Assert.Fail("DNS Resolution failed");
                }
            }
        }
    }
