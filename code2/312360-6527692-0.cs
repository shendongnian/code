    public class EmployeeViewModel // The normal one, can be used for editing
    {
        [ScaffoldColumn(false)]
        public int EmployeeId { get; set; }
    
        public virtual string Username { get; set; }
    }
    public class InsertEmloyeeViewModel : EmployeeViewModel
    {
        [Remote("UsernameExists", "Employees", ErrorMessage = "Username already exists")]
        public override string Username { get; set; }
    }
