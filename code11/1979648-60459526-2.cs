    public class EnforcingLocalSignup<TUser, TKey> : AspNetIdentityUserService<TUser, TKey> 
         where TUser : class, Microsoft.AspNet.Identity.IUser<TKey>, new() 
         where TKey : IEquatable<TKey> 
    { 
       public EnforcingLocalSignup(Microsoft.AspNet.Identity.UserManager<TUser, TKey> userManager,
           Func<string, TKey> parseSubject = null)
       { }
    }
