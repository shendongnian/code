    [HttpGet("admin/roles/create")]
    public IActionResult CreateRole()
    {
        return View();
    }
    [HttpPost("admin/roles/create")]
    public async Task CreateRole(CreateRoleViewModel model)
    {
        var flag = _roleManager.RoleExistsAsync(model.RoleName);
        // Check to see if Role Exists, if not create it
        if (flag.Result==false)
        {
            var roleResult =await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
        }
    }
