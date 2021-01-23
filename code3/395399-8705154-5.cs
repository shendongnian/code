    public ViewResult Index()
    {
        var journals = new JournalsViewModel.GetJournals();
    
        return View(journals); //You just passed journals as a model
    }
