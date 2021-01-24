    public class CustomActionFilter: IAsyncActionFilter
    {
        /// <inheritdoc />
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var parameterDescriptor in context.ActionDescriptor.Parameters)
            {
                var bindingSource = parameterDescriptor.BindingInfo.BindingSource;
                if (bindingSource == BindingSource.Body)
                {
                    // bound from body
                }
                else if (bindingSource == BindingSource.Services)
                {
                    // from services
                }
                else if (bindingSource == BindingSource.Query)
                {
                    // from query string
                }
            }
        }
    }
