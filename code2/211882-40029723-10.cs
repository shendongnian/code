    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.Routing;
    internal class MyFilterAttribute : ActionFilterAttribute
    {
        private IUrlHelperFactory _urlHelperFactory;
        public void InjectServices(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var url = _urlHelperFactory.GetUrlHelper(context).Action();
            base.OnActionExecuted(context);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var url = _urlHelperFactory.GetUrlHelper(context).Action();
            base.OnActionExecuting(context);
        }
    }
