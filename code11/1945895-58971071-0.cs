    var deptName = new MySqlParameter("@DName", department.DepartmentName);
    var deptLoc = new MySqlParameter("@DLoc", department.DepartmentLocation);
    var departments = _context
                  .Departments
                  .FromSqlRaw("CALL InsertDepartments(@DName,@DLoc)", parameters:new[] { deptName, deptLoc })
                  .ToList();
