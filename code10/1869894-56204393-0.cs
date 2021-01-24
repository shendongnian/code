.AddService<ODataUriResolver>(Microsoft.OData.ServiceLifetime.Singleton, s =>
{
    var resolver = new AlternateKeysODataUriResolver(model);
    resolver.EnableCaseInsensitive = true;
    return resolver;
})
