    public ActionResult Foo()
    {
        IEnumerable<AdminVAT> listAdminVAT = ... fetch from repo
        var model = new MyViewModel
        {
            ListVAT = Mapper.Map<IEnumerable<AdminVAT>, IEnumerable<AdminVATViewModel>>(listAdminVAT)
        };
        return View(model);
    }
