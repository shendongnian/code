    public async Task<IActionResult> OnGetAsync(string serverId) {
      if (string.IsNullOrEmpty(serverId)) {
        return NotFound();
      }
      HttpContext.Session.SetString(ServerIdKey, serverId);
      return Page();
    }
    
    public async Task<JsonResult> OnGetStartServer() {
      var serverId = HttpContext.Session.GetString(ServerIdKey);
      if (serverId == null)
      {
          // Do something, like redirect to a page where the serverId can be set by the user or whatever
      }    
      return await this.ServerManager.StartServer(serverId);
    }
