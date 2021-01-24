    namespace  CP.Controladores
    {
    public class ValidateCaptchaAttribute : ActionFilterAttribute{
        
        public override void OnActionExecuting(ActionExecutingContext 
        filterContext)
        {
             filterContext.ActionParameters["CaptchaIsValid"] = recaptchaResponse.IsValid;
             base.OnActionExecuting(filterContext);
        }
    }
