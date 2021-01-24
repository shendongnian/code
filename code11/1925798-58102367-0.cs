public class CheckPermission : ActionFilterAttribute {
        public string ArgName { get; }
        public CheckPermission(string argName)
        {
            this.ArgName = argName;
        }
        public override void OnActionExecuting(ActionExecutingContext context) {
            var controller = context.Controller as Controller;
            var identity = controller.User.Identity;
            var au = context.ActionArguments[ArgName] as AppUser;
            var auclaims = new ApplicationUser(identity);
            if (!auclaims.CanModifyUser(au)) {
                context.Result = controller.StatusCode(401, "You do not have permission to add a user to this company");
            base.OnActionExecuting(context);
        }
    }`
