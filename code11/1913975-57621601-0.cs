    public async Task<IEnumerable<object>> Test()
    {
        var result = await _context.Users.Include(s => s.UserDepartments).ThenInclude(n => n.Department).Select(p => new 
        {
                UserId = p.Id,
                FName = p.FirstName,
                LName = p.LastName,
                Depts = p.UserDepartments.Select(s=>s.Department).Select(k => k.DepartmentName)
        }).ToListAsync();        
        return result;
    }
