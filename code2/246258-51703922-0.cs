    public class Employee
        {
            static long AutoId = 0;
            public long Id { get; private set; } = ++AutoId;
            public string EmployeeName { get; set; }
            public string Address { get; set; }
        }
