await userManager.AddClaimAsync(user.Id, new Claim("FullName", user.FullName));
Create extension to Identity
namespace MyApps.Extension
{
    public static class IdentityExtension
    {
        public static string GetFullName(this IIdentity identity)
        {
            if (identity == null)
                return null;
            var fullName = (identity as ClaimsIdentity).FirstOrNull("FullName");
            return fullName;
        }
        
        internal static string FirstOrNull(this ClaimsIdentity identity, string claimType)
        {
            var val = identity.FindFirst(claimType);
            return val == null ? null : val.Value;
        }
    }
}
Later use
httpContextAccessor.HttpContext.User.Identity.GetFullName()
  [1]: https://docs.microsoft.com/en-us/aspnet/core/security/authorization/claims?view=aspnetcore-2.2
