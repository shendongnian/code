    [HttpPost]
    public ActionResult UpdateItem (Employee model)
    {
        ....
        getEmployee.Name = model.EmployeeName.ToString();
        getEmployee.Address = model.EmployeeAddress.ToString();
        ...
    } 
