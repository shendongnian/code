    public ActionResult Index()
    {
        var viewModel = new HomeIndexViewModel()
        {
            // The lists with problem areas are populated.
            problemAreas1 = new SelectList(helpDeskRepository.GetProblemAreas(), "ProblemAreaID", "ProblemAreaName"),
            problemAreas2 = new SelectList(helpDeskRepository.GetProblemAreas(), "ProblemAreaID", "ProblemAreaName"),
            problemAreas3 = new SelectList(helpDeskRepository.GetProblemAreas(), "ProblemAreaID", "ProblemAreaName")
        };
        return View(viewModel);
    }
    
    //
    // POST: /Home/
    
    [HttpPost]
    public ActionResult Index(HomeIndexViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            // the model wasn't valid =>
            // show the same form so that the user can fix validation errors
            viewModel.problemAreas1 = new SelectList(helpDeskRepository.GetProblemAreas(), "ProblemAreaID", "ProblemAreaName");
            viewModel.problemAreas2 = new SelectList(helpDeskRepository.GetProblemAreas(), "ProblemAreaID", "ProblemAreaName");
            viewModel.problemAreas3 = new SelectList(helpDeskRepository.GetProblemAreas(), "ProblemAreaID", "ProblemAreaName");
            return View(viewModel);
        }
        // TODO: everything went fine => update your database and redirect
        return RedirectToAction("Index");
    }
