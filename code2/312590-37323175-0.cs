    [HttpGet]
    public IActionResult List()
    {
       ...
       return View();
    }
    
    [HttpPost]
    public IActionResult Add()
    {
        ...
        return RedirectToAction(nameof(List));
    }
