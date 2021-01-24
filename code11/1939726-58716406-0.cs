    public class MyEndpointRoutingUrlHelper : UrlHelperBase
    {
        private readonly LinkGenerator _linkGenerator;
    
        public MyEndpointRoutingUrlHelper(
            ActionContext actionContext,
            LinkGenerator linkGenerator)
            : base(actionContext)
        {
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
        }
    
        public override string Action(UrlActionContext urlActionContext)
        {
            if (urlActionContext == null)
            {
                throw new ArgumentNullException(nameof(urlActionContext));
            }
    
            var values = GetValuesDictionary(urlActionContext.Values);
    
            if (urlActionContext.Action != null)
            {
                values["action"] = urlActionContext.Action;
    
            }
            else if (!values.ContainsKey("action") && AmbientValues.TryGetValue("action", out var action))
            {
                values["action"] = action;
            }
    
            if (urlActionContext.Controller != null)
            {
                values["controller"] = urlActionContext.Controller;
            }
            else if (!values.ContainsKey("controller") && AmbientValues.TryGetValue("controller", out var controller))
            {
                values["controller"] = controller;
            }
    
            var path = _linkGenerator.GetPathByRouteValues(
                ActionContext.HttpContext,
                routeName: null,
                values,
                fragment: new FragmentString(urlActionContext.Fragment == null ? null : "#" + urlActionContext.Fragment));
    
            return GenerateUrl(urlActionContext.Protocol, urlActionContext.Host, path);
        }
    
        public override string RouteUrl(UrlRouteContext routeContext)
        {
            if (routeContext == null)
            {
                throw new ArgumentNullException(nameof(routeContext));
            }
    
            var path = _linkGenerator.GetPathByRouteValues(
                ActionContext.HttpContext,
                routeContext.RouteName,
                routeContext.Values,
                fragment: new FragmentString(routeContext.Fragment == null ? null : "#" + routeContext.Fragment));
    
            return GenerateUrl(routeContext.Protocol, routeContext.Host, path);
        }
    
        public override string Content(string contentPath)
        {
            // override this method how you see fit
    
            return base.Content(contentPath);
        }
    }
