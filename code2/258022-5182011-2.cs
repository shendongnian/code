    newEmployee = (from emp in db.employees
                   select new 
                   {
                       emp.EmployeeID,
                       emp.Username,
                       Status = db.TimeTables.Where(d => d.Employee.Username 
                          == emp.Username && d.DateTime == DateTime.Today)
                   }).ToList();
