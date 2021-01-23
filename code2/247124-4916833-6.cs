    public class CacheModelAttribute : ActionFilterAttribute
    {
        private readonly string[] _paramNames;
        public CacheModelAttribute(params string[] paramNames)
        {
            // The request parameter names that will be used 
            // to constitute the cache key.
            _paramNames = paramNames;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var cache = filterContext.HttpContext.Cache;
            var model = cache[GetCacheKey(filterContext.HttpContext)];
            if (model != null)
            {
                // If the cache contains a model, fetch this model
                // from the cache and short-circuit the execution of the action
                // to avoid hitting the repository
                var result = new ViewResult
                {
                    ViewData = new ViewDataDictionary(model)
                };
                filterContext.Result = result;
            }
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            var result = filterContext.Result as ViewResultBase;
            var cacheKey = GetCacheKey(filterContext.HttpContext);
            var cache = filterContext.HttpContext.Cache;
            if (result != null && result.Model != null && cache[key] == null)
            {
                // If the action returned some model, 
                // store this model into the cache
                cache[key] = result.Model;
            }
        }
        private string GetCacheKey(HttpContextBase context)
        {
            // Use the request values of the parameter names passed
            // in the attribute to calculate the cache key.
            // This function could be adapted based on the requirements.
            return string.Join(
                "_", 
                (_paramNames ?? Enumerable.Empty<string>())
                    .Select(pn => (context.Request[pn] ?? string.Empty).ToString())
                    .ToArray()
            );
        }
    }
