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
                controllerModel.Attributes
                    .OfType<InversionOfControlAttribute>().ToList()
                    .ForEach(a => a.InjectServices(_urlHelperFactory));
                controllerModel.Actions.SelectMany(a => a.Attributes)
                    .OfType<InversionOfControlAttribute>().ToList()
                    .ForEach(a => a.InjectServices(_urlHelperFactory));
            }
        }
        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            // intentionally empty
        }
    }
