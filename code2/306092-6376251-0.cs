    public class MyProvider : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var rd = controllerContext.RouteData;
            var controller = rd.GetRequiredString("controller");
            if (string.Equals("admin", controller, StringComparison.OrdinalIgnoreCase) &&
                string.Equals("logon", actionDescriptor.ActionName))
            {
                return Enumerable.Empty<Filter>();
            }
            return new[]
            {
                new Filter(new AuthorizeAttribute(), FilterScope.Action, 0)
            };
        }
    }
