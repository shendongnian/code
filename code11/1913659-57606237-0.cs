    private async Task<ApplicationUser> GetUserDetailsAnsyc()
    {
      return await userManager.GetUserAnsync(HttpContext.User);
    }
    
    var user = await GetUserDetailsAnsyc();
    Console.WriteLine(user.Id.ToString());
