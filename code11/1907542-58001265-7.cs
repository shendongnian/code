    Severity	Code	Description	Project	File	Line	Suppression State
    Error	CS0121	The call is ambiguous between the following methods or properties: 'ServiceCollectionExtensions.AddAutoMapper(IServiceCollection, params Assembly[])' and 'ServiceCollectionExtensions.AddAutoMapper(IServiceCollection, params Type[])'	MyApps.EddiToolsAPI	C:\Projects\eddi\MyApp.EddiToolsAPI\Startup.cs	35	Active
    
    An unhandled exception occurred while processing the request.
    InvalidOperationException: No constructor for type 'AutoMapper.Mapper' can be instantiated using services from the service container and default values.
    Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(Type serviceType, Type implementationType, CallSiteChain callSiteChain)
    
    Stack Query Cookies Headers
    InvalidOperationException: No constructor for type 'AutoMapper.Mapper' can be instantiated using services from the service container and default values.
    Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(Type serviceType, Type implementationType, CallSiteChain callSiteChain)
    Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain)
    Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(Type serviceTypNe, CallSiteChain callSiteChain)
    Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateCallSite(Type serviceType, CallSiteChain callSiteChain)
    Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.CreateServiceAccessor(Type serviceType)
    System.Collections.Concurrent.ConcurrentDictionary<TKey, TValue>.GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
    Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
    Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type serviceType)
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
