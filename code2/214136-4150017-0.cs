		private static List<BO.Employee> ListDirectReports(int mgrId)
		{
			IQueryable<BO.Employee> directRpts;
			using(var ctx = new Entities())
			{
			    directRpts = 
			        from emp in ctx.Employee
			        join directRptHist in 
			        (from employeeHistory in ctx.EmployeeHistory
			            .Where(h => h.DirectManagerEmployeeID == mgrId)
			        group employeeHistory by employeeHistory.EmployeeID into grp 
			        let maxDt = grp.Max(g => g.DateLastUpdated) from history in grp
			        where history.DateLastUpdated == maxDt
			        select history)
			        on emp equals directRptHist.Employee
			        select emp;
			}
			return directRpts.ToList();
			
			//IQueryable<BO.Employee> employees;
			//using(var ctx = new Entities())
			//{
			
			//        //function evaluation times out on this qry:
			//    // First make sure we're only looking at the current employee information
			//    IQueryable<BO.EmployeeHistory> currentEntries = 
			//        from eh in ctx.EmployeeHistory
			//        group eh by eh.EmployeeID into grp 
			//        select grp.OrderBy(eh => eh.DateLastUpdated).FirstOrDefault();
			//    // Now filter by the manager's ID
			//    var dirRpts = currentEntries
			//        .Where(eh => eh.DirectManagerEmployeeID == mgrId);
			//    // This would be ideal, assuming your entity associations are set up right
			//    employees = dirRpts.Select(eh => eh.Employee).Distinct();
			//    //// If the above won't work, this is the next-best thing
			//    //var employees2 = ctx.Employee.Where(
			//    //                    emp => directRpts.Any(
			//    //                        eh => eh.EmployeeId == emp.EmployeeId));
			//}
			//return employees.ToList();
		}
 
