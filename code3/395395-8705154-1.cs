    public ViewResult Index()
    {
        var journals = db.Journals.AsEnumerable<Journal>();
        
        return View(journals); //You just passed journals as a model
    }
