public class InheritedUser : IdentityUser
{
   public bool HasTwoHeads { get; set;}
}
your **startup**
services.AddDefaultIdentity<InheritedUser>()
                .AddEntityFrameworkStores<CustomDbContext>()                               .AddDefaultTokenProviders()
.AddDefaultUI(Microsoft.AspNetCore.Identity.UI.UIFramework.Bootstrap4);
Then your Inherited **DbContext**
public class InheritedDbContext : IdentityDbContex<InheritedUser>
{
   
}
