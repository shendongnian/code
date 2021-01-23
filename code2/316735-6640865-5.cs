    public ActionResult Index()
    {
        // TODO: You definitively don't want to hardcode your repository like this
        // but use a constructor injection or this action will be impossible to unit test
        IRepository<Subject> subjectRepository = new Repository<Subject>();
        var subjects = subjectRepository.GetAll().OrderBy(t => t.Position).ToList();
        var model = new MyViewModel
        {
            Subjects = subjects.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            })
        };   
        return View(model);
    }
