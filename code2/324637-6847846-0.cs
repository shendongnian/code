    public class TestAuthAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
            {
                return ResultOfBusinsessLogic;
            }
          
        }
