            for (int i = 0; i < EmployeeAttandance.Count; i++)
            {
                var attendancesPerDay = EmployeeAttandance.Where(x => x.Date.Date == DateTime.Now.Date && x.EmployeeClockTimeID == EmployeeAttandance[i].EmployeeClockTimeID).ToList();
                Validation(attendancesPerDay);
                i = EmployeeAttandance.IndexOf(attendancesPerDay[attendancesPerDay.Count - 1]);
            }
 
