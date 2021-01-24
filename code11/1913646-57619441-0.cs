    [Authorize(Policy = "ADRoleOnly")]
    public IActionResult Index(string sortOrder, string searchString) {
        if (!HttpContext.Session.Keys.Contains("Sent401")) {
            HttpContext.Session.SetString("Sent401", "yes");
            return HttpUnauthorized();
        }
        
        ...
        
    }
