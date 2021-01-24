    public void GetDeptId(int _DeptID)
    {
        var depts = dbContext.tblDepartments
                            .Where(d => d.DepartmentID == _DeptID);
    }
