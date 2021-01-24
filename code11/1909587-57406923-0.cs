public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value == null) { return null; }
 
        // Slugify value
        return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}
Then you let the ASP.NET Pipeline know about this transformer, either in Razor Pages...
services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddRazorPagesOptions(options =>
{
    options.Conventions.Add(
        new PageRouteTransformerConvention(
            new SlugifyParameterTransformer()));
});
or in ASP.NET MVC:
services.AddMvc(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                 new SlugifyParameterTransformer()));
});
