    [WebGet]
    public IQueryable<Employee> GetEmployeesByProjects(List<string> projects)
    {
       var employees = from ep in CurrentDataSource.EmployeeProjects
              .Include("Project")
              .Include("Employee")
           where projects.Contains(ep.Project.ProjectName)
           select ep.Employee;
       return employees;
    }
