     public ActionResult Details(int? id)
        { 
         if(id != null)
          {                   
           EmployeeContext employeeContext = new EmployeeContext();
           Employee employee = employeeContext.Employees.Single(x =>x.EmployeeId == id);
                return View(employee);
         }
        else {
          return  SomeView();
         }
    }
