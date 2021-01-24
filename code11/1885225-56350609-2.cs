    public ActionResult DevExpressViewPartial()
    {
        IQueryable<Employee> model = GetYourDataFromSomewhere();
        return PartialView("GridView", model);
    }
