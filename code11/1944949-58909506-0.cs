    [HttpGet]
    public async Task<IActionResult> Create()
    {
      var hostAppGetQuery = new Application.Handlers.HostApps.Queries.List.Query();
      var platformGetQuery = new Application.Handlers.Platforms.Queries.List.Query();
    
      var hostApps = await _mediator.Send(hostAppGetQuery);
      var platforms = await _mediator.Send(platformGetQuery);
    
      TempData["hostApps"] = ((Application.Handlers.HostApps.Queries.List.Response) hostApps).Items;
      TempData["platforms"] = ((Application.Handlers.Platforms.Queries.List.Response) platforms).Items;
    
      return View();
    }
