    Stack Query Cookies Headers Routing 
    InvalidOperationException: The 'Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure.DefaultTempDataSerializer' cannot serialize an object of type 'System.Collections.Generic.List`1[WebMVCAPP_L.Models.Movie]'.
        Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure.DefaultTempDataSerializer.Serialize(IDictionary<string, object> values)
        Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider.SaveTempData(HttpContext context, IDictionary<string, object> values)
        Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Save()
        Microsoft.AspNetCore.Mvc.ViewFeatures.Filters.SaveTempDataFilter.SaveTempData(IActionResult result, ITempDataDictionaryFactory factory, IList<IFilterMetadata> filters, HttpContext httpContext)
        Microsoft.AspNetCore.Mvc.ViewFeatures.Filters.SaveTempDataFilter.OnResultExecuted(ResultExecutedContext context)
        Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.ResultNext<TFilter, TFilterAsync>(ref State next, ref Scope scope, ref object state, ref bool isCompleted)
        Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeResultFilters()
        Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextResourceFilter>g__Awaited|24_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, object state, bool isCompleted)
        Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Rethrow(ResourceExecutedContextSealed context)
        Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Next(ref State next, ref Scope scope, ref object state, ref bool isCompleted)
        Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeFilterPipelineAsync()
        Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
        Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
        Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
        Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)```
