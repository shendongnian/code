            // Map the domain objects to the view model.
            model.Items = timecards.Select(t =>new HoursItemViewModel
                {
                    EmployeeId = t.Employee.Id,
                    Employee = $"{t.Employee.FirstName} {t.Employee.LastName}",
                    Hours = (t.PunchOutDateUtc - t.PunchInDateUtc)?.TotalHours ?? 0
                }).GroupBy(i => i.EmployeeId).Select(g => new HoursItemViewModel
            {
                EmployeeId = g.FirstOrDefault().EmployeeId, EmployeeName = g.FirstOrDefault().EmployeeName,
                Hours = g.Sum(i => i.Hours)
            }).ToList();
