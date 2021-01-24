    public class TrackAPIAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
          var details = GetDetails(actionContext);
          
          Task.Run(() => TrackDetails(details));  //No await
    
    
        }
      ...
      ...
    }
