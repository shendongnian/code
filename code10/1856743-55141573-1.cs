    public void GetDeptId(int _DeptID)
    {
        var dept = dbContext.tblDepartments
                            .First(d => d.DepartmentID == _DeptID);
    }
