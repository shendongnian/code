    public ActionResult DevExpressView()
    {
        IQueryable<Employee> model = GetYourDataFromSomewhere();
        return View("EmployeeList", model);
    }
