    public class MyActionFilterAttribute: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Your logic to log the request, you can get the details from
            //context parameter
            
            //You can check if model state is valid also by using the property
            //context.ModelState.IsValid
        }
    }
