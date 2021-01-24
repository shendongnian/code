    public ActionResult Index()
    {
        var objects = _IObjectService.GetAll();
        ViewBag.NotPromoExist = false;
        var indexObj = new List<IndexObjectViewModel>();           
        foreach (var p in objects)
        {
            var indexModel = new IndexObjectViewModel();
            indexModel.Id = p.Id;
            indexModel.Name = p.Name;
            indexModel.Site = p.Site;
            indexModel.Users = p.Users;
            indexModel.Plannings = p.Plannings;
            indexModel.Pilote = _IUserService.Get(p.IdPilote);
            indexObj.Add(indexModel);
        }
        return View(indexObj);
    }
