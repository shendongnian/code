    void Main()
    {   
        var employeeList = new List<Employee> {
                                new Employee { EmployeeNo = "000001", Name = "DELA CRUZ, JUAN T." },
                                new Employee { EmployeeNo = "000002", Name = "GOMEZ, MAR B." }
                           };
    
        employeeList.Dump();
    }
    
    public class Employee
    {
        public string EmployeeNo { get; set; }
        public string Name { get; set; }    
    }
