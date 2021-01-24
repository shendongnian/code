        var appId = tokenS.Audiences.First();
        if (string.IsNullOrEmpty(appId))
        {
            throw new UnauthorizedAccessException(Messages.AppIdIsMissing);
        }
        var registeredAppId = _configuration.GetSection("AzureAd:AuthorizedApplicationIdList")?.Get<List<string>>();
        return (registeredAppId.Contains(appId)) ? true : false;
