    public async Task<IViewComponentResult> InvokeAsync()
    {
        var claimsIdentity = (ClaimsIdentity) User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        var userFromDb = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == claim.Value);
        var role = await _userManager.GetRolesAsync(userFromDb);
        // pass a complex object with separate properties to the view instead
        return View("Default", new MyViewComponentModel
        {
            Name = userFromDb.Name,
            Role = role[0],
        });
    }
    public class MyViewComponentModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
