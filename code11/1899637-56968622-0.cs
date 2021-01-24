        if (db.Emplooyee_Attendance.Any(a => a.Employee_ID == item.Id))
        {
           var Emp_Attendance_ID = db.Emplooyee_Attendance.Where(a => a.Employee_ID == item.Id)
                                                          .Max(p => p.Attendance_ID);
           // Rest of your code...
        }
        else
           // Do something different?
