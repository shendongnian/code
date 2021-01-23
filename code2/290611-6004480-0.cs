    public ActionResult Create()
    {
        var model = new AccountViewModel();
        return View("Create", model);
    } 
    [HttpPost]
    public ActionResult Create(AccountViewModel accountToCreate)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var newAccount = Mapper.Map<AccountViewModel, Account>(accountToCreate);
               _database.Account.AddObject(newAccount);
               _database.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
