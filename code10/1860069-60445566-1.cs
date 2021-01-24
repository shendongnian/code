    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PreventDoublePostAttribute : ActionFilterAttribute
    {
        private const string UniqFormuId = "LastProcessedToken";
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            
            IAntiforgery antiforgery = (IAntiforgery)context.HttpContext.RequestServices.GetService(typeof(IAntiforgery));
            AntiforgeryTokenSet tokens = antiforgery.GetAndStoreTokens(context.HttpContext);
            if (!context.HttpContext.Request.Form.ContainsKey(tokens.FormFieldName))
            {
                return;
            }
            
            var currentFormId = context.HttpContext.Request.Form[tokens.FormFieldName].ToString();
            var lastToken = "" + context.HttpContext.Session.GetString(UniqFormuId);
            if (lastToken.Equals(currentFormId))
            {
                context.ModelState.AddModelError(string.Empty, "Looks like you accidentally submitted the same form twice.");
                return;
            }
            context.HttpContext.Session.Remove(UniqFormuId);
            context.HttpContext.Session.SetString(UniqFormuId, currentFormId);
            await context.HttpContext.Session.CommitAsync();
         
        }
       
    }
