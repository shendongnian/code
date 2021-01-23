    public IQueryable BindEmployees(int startRowIndex, int maximumRows, out int count)
    {
        EmployeeInfoDataContext dbEmp = new EmployeeInfoDataContext();
        var query = from emp in dbEmp.Employees
                    join dept in dbEmp.Departments
                        on emp.DeptID equals dept.DeptID
                    select new
                    {
                        EmpID = emp.EmpID,
                        EmpName = emp.EmpName,
                        Age = emp.Age,
                        Address = emp.Address,
                        DeptName = dept.DepartmentName
                    };
    
        count = query.Count();
        return query.Skip(startRowIndex).Take(maximumRows);
    }
