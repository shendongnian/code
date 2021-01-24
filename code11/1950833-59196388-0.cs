    public class CentralizedRouteProvider : DefaultDirectRouteProvider
    {
        protected override IReadOnlyList<RouteEntry> GetActionDirectRoutes(HttpActionDescriptor actionDescriptor,IReadOnlyList<IDirectRouteFactory> factories, IInlineConstraintResolver constraintResolver)
        {
            var result = base.GetActionDirectRoutes(actionDescriptor, factories, constraintResolver).ToList();
            var list = new List<RouteEntry>();
            foreach (var route in result.Where(r => r.Route.RouteTemplate.Contains("[ApiGroup]")))
            {
                var attribute = ((ReflectedHttpActionDescriptor)actionDescriptor).GetCustomAttributes<ApiGroupAttribute>().First();
                var newTemplate = route.Route.RouteTemplate.Replace("[ApiGroup]", attribute.GroupName);
                if (!result.Any(r => r.Route.RouteTemplate == newTemplate))
                {
                    var entry = new RouteEntry(null, new HttpRoute(newTemplate,
                        new HttpRouteValueDictionary(route.Route.Defaults),
                        new HttpRouteValueDictionary(route.Route.Constraints),
                        new HttpRouteValueDictionary(route.Route.DataTokens)));
                    list.Add(entry);
                }
            }
            return list.AsReadOnly();
        }
    }
