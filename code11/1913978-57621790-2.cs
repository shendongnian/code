    public async Task<IEnumerable<object>> Test()
      {
            var result = await _context.Users
                 .Select(user => new
                 {
                      User = user, 
                      Departments = user.UserDepartments.Select(userDepartment => userDepartment.Department.DepartmentName)
                 })
                 .Where(tuple=> tuple.Departments.Contains("Administration"))
                 .Select(tuple=> new
                 {
                     UserId = tuple.User.Id,
                     FName = tuple.User.FirstName,
                     LName = tuple.User.LastName,
                     Depts = tuple.Departments
                 }).ToListAsync();
    
            return result;
    
      }
