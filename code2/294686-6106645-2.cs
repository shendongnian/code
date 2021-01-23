    public ActionResult Index()
    {
        var questions = repository.GetQuestions().ToArray();
        return View(questions);
    }
