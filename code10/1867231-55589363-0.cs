    AuthenticationResult result = null;
    //.... codes for getting access token
    AuthenticationContext authContext = new AuthenticationContext(authority);
    ClientCredential clientCredential = new ClientCredential(clientId, appKey);
    result = await authContext.AcquireTokenAsync(todoListResourceId, clientCredential);
    var client = new HttpClient();
    client.BaseAddress = new Uri("https://management.azure.com/")
    client.DefaultRequestHeaders.Add("Authorization", "Bearer "+result.AccessToken);
    var resp = client.DeleteAsync("subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{storageAccountName}?api-version=2018-11-01")
    return resp.StatusCode.Equals("200") ? new OkResult() : new NotFoundResult();
