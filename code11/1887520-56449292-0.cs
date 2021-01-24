        var options = new PublicClientApplicationOptions()
        {
            ClientId = <**clientid**>,
            TenantId = <**tenantid**>,
            AzureCloudInstance = AzureCloudInstance.AzurePublic,
        };
        var client = PublicClientApplicationBuilder.CreateWithApplicationOptions(options).Build();
