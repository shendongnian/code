    public class SignInResult : ActionResult
    {
         
        /// <inheritdoc />
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            ...
            await context.HttpContext.SignInAsync(AuthenticationScheme, Principal, Properties);
        }
    }
