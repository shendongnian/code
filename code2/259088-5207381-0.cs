    [HttpPost]
    public ActionResult Edit(EmployeesViewModel viewModel)
    {
        //if editing an employee, fetch it; otherwise, create a new one
        Employee employee = GetEmployee(viewModel.EmployeeId);
        TryUpdateModel(employee);
        if (ModelState.IsValid)
        {              
            SaveEmployee(employee);
            TempData["message"] = "Employee has been saved.";
            return RedirectToAction("Details", new { id = employee.EmployeeID });
        }
        // Reload employee types from repository before redisplaying the view
        viewModel.EmployeeTypes = _adminRepository.GetAllEmployeeTypes();
        // validation error, so redisplay same view
        return View(viewModel);
    }
