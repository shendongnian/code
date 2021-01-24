    public async Task<IEnumerable<object>> Test()
      {
            var adminDep = await _context.Departments
                   .Include(dep => dep.UserDepartments)
                   .ThenInclude(userDep => userDep.User.UserDepartments)
                   .SingleOrDefaultAsync(dep => dep.DepartmentName == "Administration");
            if(adminDep == null) throw new InvalidOperationException();
            var result = adminDep.UserDepartments
                    .Select(userDep => userDep.User)
                    .Select(user => new
                    {
                       UserId = User.Id,
                       FName = user .FirstName,
                       LName = user .LastName,
                       Depts = user.UserDepartments.Select(userDep => userDep.Department.DepartmentName)
                     }).ToList();
            
            return result;
    
      }
