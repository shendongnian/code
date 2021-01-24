    [HttpGet]
    public IActionResult GetPerson(int id) {
        //...
        return View();
    }
    
    [HttpPost]
    public IActionResult AddPerson(Parameter person) { 
        if (ModelState.IsValid) {
            _context.Account.Add(person);
            _context.SaveChanges();    
            return RedirectToAction("GetPerson", new { id = person.Id });    
        }    
        return View("Index");
    }
