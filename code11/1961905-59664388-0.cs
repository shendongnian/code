  [HttpGet]
    public  async Task<IActionResult> Get()
    {
        var roles = **await** _repo.GetRoles();
        return new JsonResult(roles);
    }
