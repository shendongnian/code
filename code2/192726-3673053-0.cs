    public class DateSelectorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var identifier = filterContext.RouteData.Values["identifier"] as string;
            switch (identifier)
            {
                case "today":
                    filterContext.ActionParameters["date"] = DateTime.Now;
                    break;
                case "tomorrow":
                    filterContext.ActionParameters["date"] = DateTime.Now.AddDays(1);
                    break;
            }
        }
    }
