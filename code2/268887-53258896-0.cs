    using JustRide.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    
    namespace MyProject.Web.Filters
    {
        public class IsAuthenticatedAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.User.Identity.IsAuthenticated)
                    context.Result = new RedirectToActionResult(nameof(AccountController.Index), "Account", null);
            }
        }
    }
    [AllowAnonymous, IsAuthenticated]
    public IActionResult Index()
    {
        return View();
    }
