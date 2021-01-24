    public class HangfireAuthorization : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext currentContext)
        {
           return Boolean.Parse(currentContext.GetHttpContext().Session.GetString("isAdmin"));
        }
    }
