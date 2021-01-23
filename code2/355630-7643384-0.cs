    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        public string Name { get; set; }
    }
    public class Test : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Employee> Emps { get; set; }
    }
