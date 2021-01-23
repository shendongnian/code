    public class TestA // corresponds to your Employee
    {
        public int Id { get; set; }
        public TestB TestB { get; set; } // your Employer
    }
    public class TestB // your Employer
    {
        public TestB()
        {
            TestCs = new List<TestC>();
        }
        public int Id { get; set; }
        public ICollection<TestC> TestCs { get; set; } // your EmployeeRoles
    }
    public class TestC // your EmployeeRole
    {
        public int Id { get; set; }
        public TestA TestA { get; set; } // your Employee
    }
