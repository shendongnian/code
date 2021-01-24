    public class MyActionFilter : Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = _context.Users.SingleOrDefault(i => i.NameIdentifier == context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)?.Id;
            if (id == null)
            {
               context.Result = new NotFoundObjectResult(new ResponseModel { Response = Response.UserNotFound, Message = "User not found in DB" });
               return;
            }
           
            var controller = (ControllerBase)context.Controller;
            controller.HttpContext.Items.Add("CurrentUserId", id );
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
