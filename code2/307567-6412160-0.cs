    public class PopulateEventIdInSessionAttribute : ActionFilterAttribute
    {       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {           
            object eventId = filterContext.ActionParameters["eventid"];
            if (eventId != null)
            {
                Session["EventId"] = (int)eventId;
            }
            base.OnActionExecuting(filterContext);
        }
    }
