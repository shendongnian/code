      public ICollection<Department> GetDeptId(int _DeptID)
    {
    var dept = dbContext.tblDepartments
        .Select(d => new Department
        {
            DepartmentID = e.DepartmentID,
            DepartmentName = e.DepartmentName
        }).Where(c => c.DepartmentID == _DeptID).ToList();
     return dept;
    }
