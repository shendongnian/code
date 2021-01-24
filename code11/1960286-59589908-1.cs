        var userName = HttpContext.User.Identity.Name.ToString();
        var user= userManager.FindByNameAsync(userName);
    
        var staff = applicationDbContext.Staffs.Where(m => m.ApplicationUser.Id == 
        user.Id);
    
        return await staffs.ToListAsync();
