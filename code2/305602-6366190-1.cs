    public ActionResult Details(int id) 
    {
      ViewData.Model = ProjectDetailManager.GetProjectDetailById(id); 
       ViewBag.Progress = ProjectDetailManager.GetProjectProgress();
       return View();    
    }
