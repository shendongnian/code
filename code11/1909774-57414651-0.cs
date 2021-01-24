public class ViewRenderService
{
    private readonly IRazorViewEngine _razorViewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly HttpContext _http;
    public ViewRenderService(IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider, IHttpContextAccessor ctx)
    {
        _razorViewEngine = razorViewEngine;
        _tempDataProvider = tempDataProvider;
        _http = ctx.HttpContext;
        _http.RequestServices = serviceProvider;
    }
    public async Task<string> RenderToStringAsync(RouteData routeData, string viewName, object model)
    {
        var actionContext = new ActionContext(_http, routeData, new ActionDescriptor());
        using (var sw = new StringWriter())
        {
            var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);
            // For views outside the usual Views folder
            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{viewName} does not match any available view");
            }
            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };
            var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary, new TempDataDictionary(_http, _tempDataProvider), sw, new HtmlHelperOptions());
            viewContext.RouteData = _http.GetRouteData();
            await viewResult.View.RenderAsync(viewContext);
            return sw.ToString();
        }
    }
}
So far all my Views have been found.
