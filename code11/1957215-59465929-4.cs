    public async Task<IActionResult> Index()
    {       
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(Bilgi bilgi)
    {
        if (ModelState.IsValid)
        {
            _context.Add(bilgi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View();
           
    }
    
