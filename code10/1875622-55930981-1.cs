    private readonly UserManager<IdentityUser> _userManager;
    public HomeController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> TestView()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
            
        var roles = await _userManager.GetRolesAsync(user);
            
        var matchingvalues = roles.SingleOrDefault(stringToCheck => stringToCheck.Equals("Admin"));
        if(matchingvalues != null)
        {
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
            
        return View();
    }
  
