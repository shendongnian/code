    public class RequireRequestValueAttribute : ActionMethodSelectorAttribute
    {
        public RequireRequestValueAttribute(string valueName)
        {
            ValueName = valueName;
        }
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            bool contains = false;
            contains = routeContext.HttpContext.Request.Query.ContainsKey(ValueName);   
            return contains;
        }
        public string ValueName { get; private set; }
    }
