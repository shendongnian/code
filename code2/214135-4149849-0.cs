    private List<BO.Employee> ListDirectReports(int mgrId)
    {
        using(var ctx = new Entities())
        {
            // First make sure we're only looking at the current employee information
            var currentEntries = 
                from eh in ctx.EmployeeHistory
                group employeeHistory by employeeHistory.EmployeeID into grp 
                select grp.OrderBy(eh => eh.DateLastUpdated).FirstOrDefault();
            // Now filter by the manager's ID
            var directRpts = currentEntries
                .Where(eh => eh.DirectManagerEmployeeID == mgrId);
                
            // This would be ideal, assuming your entity associations are set up right
            var employees = directRpts.Select(eh => eh.Employee).Distinct();
                            
            // If the above won't work, this is the next-best thing
            var employees2 = ctx.Employee.Where(
                                emp => directRpts.Any(
                                    eh => eh.EmployeeId == emp.EmployeeId));
    
            return employees.ToList();
        }
    }
