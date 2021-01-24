    [HttpGet("{id:int}")]     
    public async Task<ActionResult<DepartmentStudentsResponse>> GetStudents(int id) {
        DepartmentStudentsResponse departmentStudents = new DepartmentStudentsResponse();
        var department =  await _context.Departments.FindAsync(id);
        if (department != null) {
            departmentStudents.department = department;
            var listOfStudents = await _context.Students.Where(x => x.DepartmentId == id).ToListAsync();
            departmentStudents.students = listOfStudents;
            return departmentStudents;
        } else {
            return NotFound();
        }
     }
