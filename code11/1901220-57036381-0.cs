    public class TestClass
    {
         private IActionContextAccessor actionContextAccessor;
         public Test(IActionContextAccessor actionContextAccessor)
         {
             this.actionContextAccessor = actionContextAccessor;
         }
    
         public void GetClaims()
         {
            var claims = actionContextAccessor.ActionContext.HttpContext.User.Claims;
            return claims;
         }
     }
    
