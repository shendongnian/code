       public IActionResult Index()
       {
         var model = db.GetAllHouses();  // How can I do this to Server side pagination?
         return View(model.Take(50));
       } 
