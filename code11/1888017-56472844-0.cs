    public class AddPaginationHeader : Attribute, IAsyncResultFilter
    {
        // AddPaginationHeader Implementation (Result Filter)
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //PagingModel model = new PagingModel();
            //await controller.TryUpdateModelAsync(model);
            var result = context.Result as ObjectResult;
            if (result?.Value != null && result?.StatusCode >= 200 &&
                result?.StatusCode < 300)
            {
                // Trying to get the pagingModel (but getting a ParameterDescriptor type)
                var controller = context.Controller as Controller;
                var parameterDescriptor = context.ActionDescriptor.Parameters.Where(t => t.Name.Equals("pagingModel")).FirstOrDefault();
                var parameter = Activator.CreateInstance(parameterDescriptor.ParameterType);
                await controller.TryUpdateModelAsync(parameter, parameterDescriptor.ParameterType, "");
                var pagingModel = parameter;
                //Getting the media type
                string mediaType = context.HttpContext.Request.Headers["Accept"];
                // Getting the query string itself
                string queryString = context.HttpContext.Request.QueryString.ToString();
                //Implementation of the actual logic that needs the paging model
                // ...
                next();
            }
            //return Task.CompletedTask;
        }
    }
