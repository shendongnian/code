                    public class CustomAuthorizeAttribute : TypeFilterAttribute
                    {
                          public CustomAuthorizeAttribute(int input) : base(typeof(CustomAuthorize))
                          {
                              Arguments = new object[] { input };
                          }
                    }
        
