    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Models.InputModels.Posts.Create.Index model)
    {
       if (!ModelState.IsValid)
       {
         return View(model);
       }
    
       var command = _mapper.Map<Application.Handlers.Posts.Commands.Create.Command>(model);
    
       var result = await _mediator.Send(command);
       //Get your ViewData variables here
       if (TempData["hostApps"] != null)
       {
        var hostAppsResult = (((Application.Handlers.HostApps.Queries.List.Response) hostApps).Items) TempData["hostApps"];
            ...
       }
       //Get your ViewData variables here
       if (TempData["platforms"] != null)
       {
        var platformsResult = (((Application.Handlers.Platforms.Queries.List.Response) platforms).Items) TempData["platforms"];
            ...
       }
    
        return View();
    }
