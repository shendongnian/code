    public class WrapApiResponseResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result;
            if (result is ObjectResult)
            {
                // wrap the inner object
                var newValue = new WrapperObject(result.Value);
                // replace the result
                context.Result = new ObjectResult(newValue)
                {
                    // copy the status code
                    StatusCode = result.StatusCode,
                };
            }
        }
        public void OnResultExecuted(ResultExecutedContext context)
        { }
    }
