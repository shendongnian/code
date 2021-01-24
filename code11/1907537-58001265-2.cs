    An unhandled exception occurred while processing the request.
    InvalidOperationException: Unable to resolve service for type 'AutoMapper.IMapper' while attempting to activate 'EddiTools.Controllers.CalculationsController'.
    Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, bool isDefaultParameterRequired)
    
    Stack Query Cookies Headers
    InvalidOperationException: Unable to resolve service for type 'AutoMapper.IMapper' while attempting to activate 'EddiTools.Controllers.CalculationsController'.
    Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, bool isDefaultParameterRequired)
    lambda_method(Closure , IServiceProvider , object[] )
    Microsoft.AspNetCore.Mvc.Controllers.ControllerActivatorProvider+<>c__DisplayClass4_0.<CreateActivator>b__0(ControllerContext controllerContext)
    Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider+<>c__DisplayClass5_0.<CreateControllerFactory>g__CreateController|0(ControllerContext controllerContext)
    Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(ref State next, ref Scope scope, ref object state, ref bool isCompleted)
    Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.InvokeInnerFilterAsync()
    Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeNextResourceFilter()
    Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)
    Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(ref State next, ref Scope scope, ref object state, ref bool isCompleted)
    Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeFilterPipelineAsync()
    Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeAsync()
    Microsoft.AspNetCore.Routing.EndpointMiddleware.Invoke(HttpContext httpContext)
    Microsoft.AspNetCore.Routing.EndpointRoutingMiddleware.Invoke(HttpContext httpContext)
    Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)
