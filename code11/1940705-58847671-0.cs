    internal class DatabaseRoles : IAuthorizationRequirement
        {
            public string Role { get; }
    
            public DatabaseRoles(string role)
            {
                Role = role;
            }
        }
    
        internal class DatabaseRolesHandler : AuthorizationHandler<DatabaseRoles>
        {
            private readonly UserManager<IdentityUser> userManager;
    
            public DatabaseRolesHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                this.userManager = userManager;
            }
    
            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, DatabaseRoles requirement)
            {
                //NOTE this is the out of the box implementation of roles and simple query to get the roles from the EF backed database. I would recoment makeing a custom privelages store for this and not using roles for this but access rights
                var user = await userManager.FindByIdAsync(userManager.GetUserId(context.User));
                if (await userManager.IsInRoleAsync(user, requirement.Role))
                {
                    context.Succeed(requirement);
                }
            }
    
        }
