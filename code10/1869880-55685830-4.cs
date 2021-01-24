    public class EmployeeAttendanceEqualityComparer : IEqualityComparer<EmployeeAttendance>
        {
            public bool Equals(EmployeeAttendance x, EmployeeAttendance y)
            {
                if (x == null || y == null)
                    return false;
    
                // check your equality same as this
                return x.Employee == y.Employee;
            }
    
            public int GetHashCode(EmployeeAttendance obj)
            {
                // or something else
                return 12;
            }
        }
