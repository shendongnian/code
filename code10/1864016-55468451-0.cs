    public override void OnActionExecuting(ActionExecutingContext context)
        {
            var parameters = context.ActionDescriptor.Parameters;
            var queryParameters = context.HttpContext.Request.Query;
            if (queryParameters.Select(kvp => kvp.Key).All(queryParameter => parameters.Any(p => p.Name == queryParameter)))
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new BadRequestObjectResult("Querystring does not match");
            }
        
        }
