    IQueryable<EmployeeHistory> GetAllReportsOfType1(string departmentId)
    {
        return context.EmployeeHistory
            .Where(eh => eh.ReportType == "type1" && eh.Employee.Department.DepId == departmentId)
            .OrderBy(eh => eh.TimeStamp);
    }
