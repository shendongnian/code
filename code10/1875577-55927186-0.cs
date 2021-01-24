    var uriBuilder = new UriBuilder(_uri);
    // If you already have query parameters, this code will preserve them. 
    // Otherwise you can just create a new NameValueCollection instance.
    var parameters = HttpUtility.ParseQueryString(uriBuilder.Query);
    parameters[nameof(userName)] = userName;
    parameters[nameof(serialNumber)] = serialNumber;
    
    uriBuilder.Query = parameters.ToString();
    
    // Pass null as HttpContent to make HttpClient send an empty body
    var result = await _httpClient.PostAsync(uriBuilder.ToString(), null).ConfigureAwait(false);
