    [HttpPost]
    public ActionResult Create(CompanyViewModel viewModel, [Bind(Prefix="Employees")] List<EmployeeViewModel> Employees)
    {
        ...
    }
