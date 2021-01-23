    newEmployee = (db.employees.Select(emp => new
                      {
                          emp.EmployeeID,
                          emp.Username,
                          Status = db.TimeTables
                          .Where(d => d.Employee.Username == emp.Username 
                              && d.DateTime == DateTime.Today)
                      })).ToList();
