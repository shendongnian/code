    using System.Linq;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.AspNetCore.Mvc.Routing;
    public class MyApplicationModelProvider : IApplicationModelProvider
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
                controllerModel.Attributes
                    .OfType<InversionOfControlAttribute>().ToList()
                    .ForEach(a => a.UrlHelperFactory = _urlHelperFactory);
                controllerModel.Actions.SelectMany(a => a.Attributes)
                    .OfType<InversionOfControlAttribute>().ToList()
                    .ForEach(a => a.UrlHelperFactory = _urlHelperFactory);
            }
        }
        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            // intentionally empty
        }
    }
