    var roleManager= new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
    
    //Get admin role
    var adminRole= roleManager.FindByName("Admin");
    var admins=context.Users.Where(x=>x.Roles.Any(role=>role.RoleId==adminRole.Id)).ToList().OrderBy(d=>d.DateCreated);
