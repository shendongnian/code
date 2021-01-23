    [HttpPost]
    public ActionResult Edytuj(ProduktyEdytujViewModel model) 
    {
        if (!ModelState.IsValid)
        {
            model.Produkt = sklepBaza.PobierzProduktWgId(model.id); 
            model.Kategorie = sklepBaza.PobierzKategorieProduktow(); 
            return View(model);
        }
        return RedirectToAction("Kategorie");
    }
