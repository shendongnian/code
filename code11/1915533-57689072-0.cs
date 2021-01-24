    public class FooAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Store the value...
            context.HttpContext.Items.Add("MyValue", 100);
            base.OnActionExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // Retrieve the value...
            if (context.HttpContext.Items.TryGetValue("MyValue", out var value))
            {
                // We know this is an int so cast it
                var intValue = (int)value;
            }
            base.OnResultExecuted(context);
        }
    }
