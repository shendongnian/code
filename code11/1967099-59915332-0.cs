`
// note that the base class is RazorViewEngine, NOT WebFormViewEngine
public class ExpandedViewEngine : RazorViewEngine
{
    public ExpandedViewEngine()
    {
        var viewLocations = new[]
        {
            "~/Views/{1}/{0}.aspx",
            "~/Views/{1}/{0}.ascx",
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.aspx",
            "~/Views/Shared/{0}.ascx",
            "~/Views/Shared/{0}.cshtml",
            "~/Areas/B2b/Views/{1}/{0}.aspx",
            "~/Areas/B2b/Views/{1}/{0}.ascx",
            "~/Areas/B2b/Views/{1}/{0}.cshtml",
            "~/Areas/B2b/Views/Shared/{0}.aspx",
            "~/Areas/B2b/Views/Shared/{0}.ascx",
            "~/Areas/B2b/Views/Shared/{0}.cshtml",
            "~/Areas/B2b/Views/Shopify/{1}/{0}.aspx",
            "~/Areas/B2b/Views/Shopify/{1}/{0}.ascx",
            "~/Areas/B2b/Views/Shopify/{1}/{0}.cshtml"
        };
        PartialViewLocationFormats = viewLocations;
        ViewLocationFormats = viewLocations;
        MasterLocationFormats = viewLocations;
    }
}
`
And configured the website to use the above view engine in `Global.asax`:
`
public class MvcApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        ViewEngines.Engines.Clear();
        ViewEngines.Engines.Add(new ExpandedViewEngine());
        AreaRegistration.RegisterAllAreas();
   
        // mpre configuratins...     
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
}
`
      
  [1]: https://stackoverflow.com/questions/17178688/controller-in-sub-folder/17238719#comment105940864_17238719
  [2]: https://stackoverflow.com/questions/632964/can-i-specify-a-custom-location-to-search-for-views-in-asp-net-mvc/7557275#7557275
