    public class Employee
    {
    
     public int EmployeeId { get; set; }
    
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
    
    public class  Permission {
    
    public virtual ICollection<Employee> Employee{ get; set; }
    }
