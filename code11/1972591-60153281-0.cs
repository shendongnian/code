    var employeeArea = (from e in db.EmployeeArea
                        select new EmployeeArea
                                   {
                                      Id = e.Id
                                      // continue populating the model with other properties
                                      EmployeeNames = db.EmployeeName.Where(e => 
                                      e.EmployeeAreaId == e.Id).ToList(),
                                   }).ToList()
