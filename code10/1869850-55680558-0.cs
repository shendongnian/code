    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } 
        public DateTime? LoginDate { get; set; }
        public bool IsActive{ get; set; }    
    
        public ICollection<Role> Roles { get; set; }
    }
    
    public class Employee : User
    {
        public string Name{ get; set; }
        public string Email { get; set; }
    }
    
    public class Operator : Employee
    {
    }
