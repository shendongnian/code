    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PreventDoublePostAttribute : ActionFilterAttribute
    {
        private const string TokenSessionName = "LastProcessedToken";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var antiforgeryOptions = context.HttpContext.RequestServices.GetOption<AntiforgeryOptions>();
            var tokenFormName = antiforgeryOptions.FormFieldName;
            if (!context.HttpContext.Request.Form.ContainsKey(tokenFormName))
            {
                return;
            }
            var currentToken = context.HttpContext.Request.Form[tokenFormName].ToString();
            var lastToken = context.HttpContext.Session.GetString(TokenSessionName);
            if (lastToken == currentToken)
            {
                context.ModelState.AddModelError(string.Empty, "Looks like you accidentally submitted the same form twice.");
                return;
            }
            context.HttpContext.Session.SetString(TokenSessionName, currentToken);
        }
    }
