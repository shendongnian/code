      [HttpPost("")]
      public IActionResult Index(IndexViewModel viewModel)
      {
        viewModel.Origin = "POST";
        // persist model or use TempData
        return RedirectToAction("AfterPost");   
      }
        
      public IActionResult AfterPost()
      {
        // get model or retrieve from TempData
        viewModel.Name = "Fixed Name"; // I want to force this value
        return View(viewModel);
      }
