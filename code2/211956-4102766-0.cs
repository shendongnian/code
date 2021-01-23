    public class AcceptParameterAttribute : ActionMethodSelectorAttribute
    {
        public string Name { get; private set; }
        public AcceptParameterAttribute(string name)
        {
            Name = name;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            HttpRequestBase req = controllerContext.HttpContext.Request;
            return req.Form[Name] != null;
        }
    }
