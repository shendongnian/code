    using System.Linq;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.AspNetCore.Mvc.Routing;
    public class MyApplicationModelProvider : IApplicationModelProvider
    {
        private IUrlHelperFactory _urlHelperFactory;
        // constructor injection
        public MyApplicationModelProvider(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }
        public int Order { get { return -1000 + 10; } }
        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
            foreach (var controllerModel in context.Result.Controllers)
            {
                // pass the depencency to controller attibutes
                controllerModel.Attributes
                    .OfType<MyAttribute>().ToList()
                    .ForEach(a => a.UrlHelperFactory = _urlHelperFactory);
                // pass the dependency to action attributes
                controllerModel.Actions.SelectMany(a => a.Attributes)
                    .OfType<MyAttribute>().ToList()
                    .ForEach(a => a.UrlHelperFactory = _urlHelperFactory);
            }
        }
        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            // intentionally empty
        }
    }
