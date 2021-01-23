    namespace MyCompany.Applications.MyApplication.Presentation.Web.Helpers
    {
        internal static class SessionHelpers
        {
    
            internal static void LogoutUser(System.Web.HttpContext context)
            {
                context.Session[SessionVariableKeys.USER_ID] = null;
                context.Session[SessionVariableKeys.RETURN_TO_PAGE] = null;
                /* or */
                context.Session.Remove(SessionVariableKeys.USER_ID);
                context.Session.Remove(SessionVariableKeys.RETURN_TO_PAGE);
                /* or */
                context.Session.RemoveAll();
                /* and */
                /* icing on the cake */
                context.Session.Abandon();
                context.Response.Redirect("SomePage.aspx");
            }
    
        }
    }
