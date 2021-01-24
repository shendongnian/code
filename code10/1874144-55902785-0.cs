    public class ChildHandlerAsyncPageFilter : IAsyncPageFilter
    {
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var pageHandlerExecutedContext = await next();
            if (pageHandlerExecutedContext.HandlerMethod?.MethodInfo.GetCustomAttribute<ChildHandlerAttribute>() == null)
            {
                return;
            }
            var referrer = context.HttpContext.Request.Headers["Referer"].ToString();
            var request = pageHandlerExecutedContext.HttpContext.Request;
            if ($"{request.Scheme}://{request.Host}/" != referrer)
            {
                pageHandlerExecutedContext.Result = new NotFoundResult();
            }
        }
        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) => Task.CompletedTask;
    }
