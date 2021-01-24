    public async Task<IEnumerable<object>> Test()
      {
            var result = await _context.Users
                 .Select(user => new
                 {
                      User = user, 
                      Departments = user.UserDepartments.Select(userDepartment => userDepartment.Department.DepartmentName)
                 })
                 .Where(pair => pair.Departments.Contains("Administration"))
                 .Select(pair => new
                 {
                     UserId = pair.User.Id,
                     FName = pair.User.FirstName,
                     LName = pair.User.LastName,
                     Depts = pair.Departments
                 }).ToListAsync();
    
            return result;
    
      }
