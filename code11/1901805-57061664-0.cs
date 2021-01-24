    public ActionResult Create()
    {
        var model = new Joueur();
        List<Strings> posteList = new List<SelectListItem>{ "Gardien", "Défenseur", "Milieu", "Attaquant" };
        ViewBag.PosteList = posteList;
        return View(model);
    }
