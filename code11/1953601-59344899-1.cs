cs
var htmlBody = await Renderer.RenderToString($"/Views/Shared/confirm-email.cshtml", model);
**The service:**
cs
public class ViewRenderService : IViewRenderService
{
    private readonly IRazorViewEngine _razorViewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IHttpContextAccessor _contextAccessor;
    public ViewRenderService(IRazorViewEngine razorViewEngine,
                             ITempDataProvider tempDataProvider,
                             IHttpContextAccessor contextAccessor)
    {
        _razorViewEngine = razorViewEngine;
        _tempDataProvider = tempDataProvider;
        _contextAccessor = contextAccessor;                                                                                            
    }
    public async Task<string> RenderToString(string viewName, object model)
    {
        var actionContext = new ActionContext(_contextAccessor.HttpContext, _contextAccessor.HttpContext.GetRouteData(), new ActionDescriptor());
        await using var sw = new StringWriter();
        var viewResult = FindView(actionContext, viewName);
        if (viewResult == null)
        {
            throw new ArgumentNullException($"{viewName} does not match any available view");
        }
        var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
        {
                Model = model
        };
        var viewContext = new ViewContext(
            actionContext,
            viewResult,
            viewDictionary,
            new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
            sw,
            new HtmlHelperOptions()
        );
        await viewResult.RenderAsync(viewContext);
        return sw.ToString();
    }
    private IView FindView(ActionContext actionContext, string viewName)
    {
        var getViewResult = _razorViewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: true);
        if (getViewResult.Success)
        {
            return getViewResult.View;
        }
        var findViewResult = _razorViewEngine.FindView(actionContext, viewName, isMainPage: true);
        if (findViewResult.Success)
        {
            return findViewResult.View;
        }
        var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
        var errorMessage = string.Join(
            Environment.NewLine,
            new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations));
        throw new InvalidOperationException(errorMessage);
    }
}
Now it works perfectly.
