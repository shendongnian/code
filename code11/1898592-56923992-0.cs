    protected override void Seed(Logintest.Models.ApplicationDbContext context)
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", 
              "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;
            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("jay", false) == null)
            {
                membership.CreateUserAndAccount("jay", "otoole");
            }
            if (!roles.GetRolesForUser("jay").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "jay" }, new[] { "admin" });
            }
        }
