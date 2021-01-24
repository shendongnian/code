        public class TokenRefrehFilter : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                //check whether action is authorized attribute
                var isAuthorizedAction = context.Filters.Any(f => f.GetType() == typeof(AuthorizeFilter));
            }
        }
