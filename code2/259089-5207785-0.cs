        public ActionResult Edit(int id)
        {
            var employee = GetEmployee(id);
            if(employee == null)
            {
                TempData["message"] = "No employee exists with an ID of " + id + ", you can create a new employee here.";
                return RedirectToAction("Create");    
            }
            var viewModel = new EmployeesViewModel
            {
                EmployeeId = employee.EmployeeID,
                EmployeeTypeId = employee.EmployeeTypeID,
                Name = employee.Name
            };
            return EditEmployeeView(viewModel);
        }
        public ActionResult EditEmployeeView(EmployeesViewModel viewModel)
        {
            viewModel.EmployeeTypes = viewModel.EmployeeTypes ?? EmployeeTypes = _adminRepository.GetAllEmployeeTypes();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(EmployeesViewModel viewModel)
        {
            Employee employee = GetEmployee(viewModel.EmployeeId);
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                SaveEmployee(employee);
                TempData["message"] = "Employee has been saved.";
                return RedirectToAction("Details", new { id = employee.EmployeeID });
            }
            return EditEmployeeView(viewModel);
        }
