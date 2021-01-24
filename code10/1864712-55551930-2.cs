csharp
services
    .TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
services
    .AddSingleton<IContentLinkUrlResolver, RoutesContentLinkUrlResolver>()
    .AddDeliveryClient( ... )
;
In `RoutesContentLinkUrlResolver.cs`:
csharp
private readonly IUrlHelperFactory urlHelperFactory;
private readonly IActionContextAccessor actionContextAccessor;
public RoutesContentLinkUrlResolver(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
{
    this.urlHelperFactory = urlHelperFactory;
    this.actionContextAccessor = actionContextAccessor;
}
public string ResolveLinkUrl(ContentLink link)
{
    IUrlHelper Url = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
    switch (link.ContentTypeCodename)
    {
        case "Page":
            return Url.Action("Page", "Home", new { codename = link.Codename });
    }
}
The instance of `IUrlHelper` is retrieved as late as possible to make sure it has the latest runtime values. The default implementation of `IUrlHelperFactory` uses caching for performance: [UrlHelperFactory line 44](https://github.com/aspnet/AspNetCore/blob/release/2.2/src/Mvc/Mvc.Core/src/Routing/UrlHelperFactory.cs#L44).
