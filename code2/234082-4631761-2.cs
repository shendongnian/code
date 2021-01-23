	DataContext Data = new DataContext();
	var PR = (from c in Data.System_Times
				 where c.Period == Period && c.Premium == true
				     && !Data.Premiums.Any(p => p.ProjectID == c.ProjectID && p.EmployeeID == c.ProjectID) 
                 orderby c.System_Employee.LName select c)
				 .GroupBy(s => s.EmployeeID & s.ProjectID)
				 .Select(x => x.FirstOrDefault());
	return PR;
