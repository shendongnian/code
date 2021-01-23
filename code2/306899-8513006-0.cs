    public class PreSubmitWarningMessage : ActionFilterAttribute
    {    
        private string _warningMessage;
        public PreSubmitWarningMessage(string warningMessage)
        {
            _warningMessage = warningMessage;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // stuff you do here will happen before the 
            // controller action is executed.
            // you can compare the private warning message 
            // to the metadata in filterContext
        }
    }
