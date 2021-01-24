var c= _configuration.GetSection(nameof(Configuration)).Get<List<Configuration>>();
foreach (Configuration r in c)
{
   services.AddAuthorization(options => {
                   options.AddPolicy("RolePolicy" + r.title, policy => 
                       policy.RequireRole(r.RoleMembers.Split(",")));
                   });
}
I think your split call on rolemembers would work, but I haven't tried it.
And assuming the title for one of the entries in the config section was "AdminOnly"
[Authorize(Policy = "RolePolicyAdminOnly")]
I think that will give you what you want.
