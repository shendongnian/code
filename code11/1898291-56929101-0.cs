    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
