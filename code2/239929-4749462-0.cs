    public class TrackerFilterAttribute : ActionFilterAttribute
    {
        public TrackerFilterAttribute()
        {
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            
            //TODO: Do my tracking here.
        }
    }
