     public class RegistrationActionTokenAttribute : ActionMethodSelectorAttribute
        {
            public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
            {
                if (controllerContext.HttpContext.Request.QueryString.AllKeys.Contains("registrationToken"))
                {
                    return true;
                }
                return false;
            }
        }
