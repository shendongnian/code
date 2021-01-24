csharp
services
    .AddTransient<IActionContextAccessor, ActionContextAccessor>()
    .AddSingleton<IContentLinkUrlResolver, RoutesContentLinkUrlResolver>()
    .AddDeliveryClient( ... )
;
In `RoutesContentLinkUrlResolver.cs`:
csharp
private readonly IUrlHelper Url;
public RoutesContentLinkUrlResolver(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
{
    Url = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
}
public string ResolveLinkUrl(ContentLink link)
{
    switch (link.ContentTypeCodename)
    {
        case "Page":
            return Url.Action("Page", "Home", new { codename = link.ContentTypeCodename });
    }
}
