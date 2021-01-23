    [HttpPost]
    public ActionResult SaveEmployee(int Id, [ModelBinder(typeof(MyPropertyBinder))] EmployeeViewModel viewModel)
    {
            // do stuff here
    }
