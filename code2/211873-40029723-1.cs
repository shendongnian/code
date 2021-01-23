    namespace WebApp
    {
        using Microsoft.AspNetCore.Mvc.ApplicationModels;
        using Microsoft.AspNetCore.Mvc.Routing;
        using System.Linq;
    
        internal class MyApplicationModelProvider : IApplicationModelProvider
        {
            private IUrlHelperFactory _urlHelperFactory;
    
            public MyApplicationModelProvider(IUrlHelperFactory urlHelperFactory)
            {
                _urlHelperFactory = urlHelperFactory;
            }
    
            public int Order { get { return -1000 + 10; } }
    
            public void OnProvidersExecuted(ApplicationModelProviderContext context)
            {
                foreach (var controllerModel in context.Result.Controllers)
                {
                    foreach (var attribute in controllerModel.Attributes.OfType<MyActionFilterAttribute>())
                    {
                        (attribute as MyActionFilterAttribute).InjectServices(_urlHelperFactory);
                    }
    
                    foreach (var actionModel in controllerModel.Actions)
                    {
                        foreach (var attribute in actionModel.Attributes.OfType<MyActionFilterAttribute>())
                        {
                            (attribute as MyActionFilterAttribute).InjectServices(_urlHelperFactory);
                        }
                    }
                }
            }
    
            public void OnProvidersExecuting(ApplicationModelProviderContext context)
            {
                // intentionally empty
            }
        }
    }
