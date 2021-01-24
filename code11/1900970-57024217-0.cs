Layout = (string)ViewData["LayoutName"] ?? "DefaultLayout";
This way you can change the layout using the action, or from inside the view or using an Action filter. I will include an Action filter that does the following using the Controller name, like you asked, and then you can register the filter globally.
C#
    public class LayoutNameFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result as ViewResult;
            var controllerName = context.RouteData.Values["controller"].ToString();
            switch (controllerName)
            {
                case "Register":
                    result.ViewData["LayoutName"] = "_RegisterLayout";
                    break;
                case "Login":
                    result.ViewData["LayoutName"] = "_LoginLayout";
                    break;
                default:
                    result.ViewData["LayoutName"] = "_Layout";
                    break;
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
And then you can register this filter globally by replacing the services.AddMvc like this.
services.AddMvc(options =>
            {
                options.Filters.Add(new SampleFilter());
            })
Hope this helps.
