    public class MyRoleValidator : RoleValidator<Role>
    {
        public override async Task<IdentityResult> ValidateAsync(RoleManager<Role> manager, Role role)
        {
            var roleName = await manager.GetRoleNameAsync(role);
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "RoleNameIsNotValid",
                    Description = "Role Name is not valid!"
                });
            }
            else
            {
                var owner = await manager.Roles.FirstOrDefaultAsync(x => x.ApplicationId == role.ApplicationId && x.NormalizedName == roleName);
                if (owner != null && !string.Equals(manager.GetRoleIdAsync(owner), manager.GetRoleIdAsync(role)))
                {
                    return IdentityResult.Failed(new IdentityError
                    {
                        Code = "DuplicateRoleName",
                        Description = "this role already exist in this App!"
                    });
                }
            }
            return IdentityResult.Success;
        }
    }
