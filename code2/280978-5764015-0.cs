    public ActionResult MultiModel()
    {
        MultiList<User, Company> result = MultiList.New(
            this.repository.GetUsers(),
            this.repository.GetCompanies()
        );
        return View(result);
    }
