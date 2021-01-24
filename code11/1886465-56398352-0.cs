cs
var authorizeFilter = new AuthorizeFilter(new List<IAuthorizeData> {
    new AuthorizeAttribute()
    {
        AuthenticationSchemes = authenticationSchemes
    }
});
Then I had to write my own IPageApplicationModelConvention that will apply at the area level. The default methods work at folder and page levels. I used the source code from [Microsoft.AspNetCore.Mvc.RazorPages](https://github.com/aspnet/Mvc/blob/master/src/Microsoft.AspNetCore.Mvc.RazorPages/ApplicationModels/PageConventionCollection.cs) as a guide.
cs
public class AreaModelConvention : IPageApplicationModelConvention
{
    private readonly string _areaName;
    private readonly Action<PageApplicationModel> _action;
    public AreaModelConvention(string areaName, Action<PageApplicationModel> action)
    {
        _areaName = areaName;
        _action = action;
    }
    public void Apply(PageApplicationModel model)
    {
        if(string.Equals(_areaName, model.AreaName, StringComparison.OrdinalIgnoreCase))
        {
            _action(model);
        }
    }
}
I wrote some PageConventionCollectionExtensions which is how this is all done in [Microsoft.AspNetCore.Mvc.RazorPages](https://github.com/aspnet/Mvc/blob/master/src/Microsoft.AspNetCore.Mvc.RazorPages/DependencyInjection/PageConventionCollectionExtensions.cs).
cs
public static class PageConventionCollectionExtensions
{
    public static PageConventionCollection RequireAuthenticationSchemesForArea(this PageConventionCollection conventions, string areaName, string authenticationSchemes)
    {
        if (conventions == null)
        {
            throw new ArgumentNullException(nameof(conventions));
        }
        if (string.IsNullOrEmpty(areaName))
        {
            throw new ArgumentException(nameof(areaName));
        }
        var authorizeFilter = new AuthorizeFilter(new List<IAuthorizeData> {
            new AuthorizeAttribute()
            {
                AuthenticationSchemes = authenticationSchemes
            }
        });
        conventions.AddAreaModelConvention(areaName, model => model.Filters.Add(authorizeFilter));
        return conventions;
    }
    public static IPageApplicationModelConvention AddAreaModelConvention(this ICollection<IPageConvention> pageConventions, string areaName, Action<PageApplicationModel> action)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        var convention = new AreaModelConvention(areaName, action);
        pageConventions.Add(convention);
        return convention;
    }
}
Finally I can register it all:
cs
services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AllowAnonymousToNonareas();
        options.Conventions.RequireAuthenticationSchemesForArea("Admin", "Windows");
        options.Conventions.RequireAuthenticationSchemesForArea("Api", "ApiKey");
    })
Note: The code for AllowAnonymousToNonareas is not defined here but it is very similar. I created a NonareaModelConvention with this Apply method:
public void Apply(PageApplicationModel model)
{
    if (model.AreaName == null)
    {
        _action(model);
    }
}
and wrote similar extension methods to tie it together.
Remember to turn on both anonymous authentication and windows authentication for the app.
