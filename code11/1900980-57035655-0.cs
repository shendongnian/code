    public IActionResult Create()
        {
           
            ViewBag.Types = new SelectList(_context.Types, "Id", "Name");
            return View();
        }
       
    [HttpPost]
    public IActionResult Create(EventViewModel vm)
        {
            
            if (!ModelState.IsValid)
            {
               
                ViewBag.Types = new SelectList(_context.Types, "Id", "Name",vm.TypeId);
                return View(vm);
            }
            //other logiv
         }
