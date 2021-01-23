    newEmployee = (from emp in db.employees
                   select new 
                   {
                       a.EmployeeID,
                       a.Username,
                       Status = db.TimeTables.Where(d => d.Employee.Username 
                          == a.Username && d.DateTime == DateTime.Today)
                   }).ToList();
