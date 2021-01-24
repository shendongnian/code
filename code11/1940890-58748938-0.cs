public class ServiceClass
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IUrlHelperFactory _urlHelperFactory;
        public ServiceClass(IActionContextAccessor actionContextAccessor,
            IUrlHelperFactory urlHelperFactory,)
        {
            _actionContextAccessor = actionContextAccessor;
            _urlHelperFactory = urlHelperFactory;
        }
        public string CreateUrl()
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            string url = urlHelper.Action("SomeAction", "SomeController");
            return url;
        }
    }
