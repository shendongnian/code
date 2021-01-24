    public ActionResult Index()
    {
        //this one was not being used:
        var departments = _departmentService.GetDepartments();
        return View(departments); //this is how you pass the model to the view.
    }
