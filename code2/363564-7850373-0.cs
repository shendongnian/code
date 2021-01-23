    public ActionResult Details(int id)
    {
        var user = _nhibernate.Get<User>(id);
        var company = _nhibernate.Get<Company>(user.CompanyId);
        var model = new DetailsModel{
           CompanyName = company.Name,
           UserName = user.Name
        };
        return View(model);
    }
