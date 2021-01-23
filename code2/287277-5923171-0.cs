    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string Message { get; set; }
    
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var result = new ViewResult();
            result.ViewName = "Login.cshtml";        //this can be a property
            result.MasterName = "_Layout.cshtml";    //this can also be a property
            result.ViewBag.Message = this.Message;
            filterContext.Result = result;
        }
    }
