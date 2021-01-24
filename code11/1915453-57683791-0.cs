cs
    public class HashIdFilterAttribute : ActionFilterAttribute, IOrderedFilter, IResourceFilter
    {
        public new int Order => int.MinValue;
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            return;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            ProcessRouteData(context.RouteData);
        }
        private void ProcessRouteData(RouteData routeData)
        {
            foreach ((string paramKey, object value) in routeData.Values)
            {
                if (paramKey.EndsWith("id", StringComparison.OrdinalIgnoreCase))
                {
                    routeData.Values[paramKey] = HashIdsUtility.DecodeInt(value as string);
                }
            }
        }
    }
  [1]: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.2#resource-filters
