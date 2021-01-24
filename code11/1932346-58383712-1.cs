    /// <summary>
    /// Add a parameter to use on every request made with this client instance
    /// </summary>
    /// <param name="restClient">The IRestClient instance</param>
    /// <param name="p">Parameter to add</param>
    /// <returns></returns>
    public static IRestClient AddDefaultParameter(this IRestClient restClient, Parameter p)
    {
        if (p.Type == ParameterType.RequestBody)
        {
            throw new NotSupportedException(
                "Cannot set request body from default headers. Use Request.AddBody() instead.");
        }
        restClient.DefaultParameters.Add(p);
        return restClient;
    }
