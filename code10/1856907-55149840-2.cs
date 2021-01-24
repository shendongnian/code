    public class Company
    {
        public string CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
    public class EmployeeCompany
    {
        [Required]
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
    public class Employee
    {
        //..
        public EmployeeCompany Company { get; set; }
    }
