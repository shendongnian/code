    private async Task CreateUserRoles()
    {   
        IdentityResult roleResult;
        //Adding Admin Role
        var roleCheck = await _roleManager.RoleExistsAsync("Admin");
        if (!roleCheck)
        {
            IdentityRole adminRole = new IdentityRole("Admin");
            //create the roles and seed them to the database
            roleResult = await _roleManager.CreateAsync(adminRole);
            _roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.AuthorizationDecision, "edit.post")).Wait();
            _roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.AuthorizationDecision, "delete.post")).Wait();
            ApplicationUser user = new ApplicationUser {
                UserName = "YourEmail", Email = "YourEmail",
                
            };
            _userManager.CreateAsync(user, "YourPassword").Wait();
            await _userManager.AddToRoleAsync(user, "Admin");
        }
    }
