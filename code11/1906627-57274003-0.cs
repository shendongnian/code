    [HttpGet]
    public IActionResult TotaleOreComplessivo() 
    {
       decimal somma = 0;
       var cedolini = _repoC.GetAll().Result;
       foreach (Cedolino cedo in cedolini) {
           somma += cedo.NumeroOre;
       }
       var model = new MyModel { Somma = somma };
       return View(model);
    }
