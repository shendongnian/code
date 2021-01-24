    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
