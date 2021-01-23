    public ActionResult Index()
    {
        var model = new SomeViewModel
        {
            // TODO: Use a repository
            ActiveCompanies = new[]
            {
                new Company { Id = 1, Name = "Company 1" },
                new Company { Id = 2, Name = "Company 2" },
                new Company { Id = 3, Name = "Company 3" },
            }
        }
        return View(model);
    }
