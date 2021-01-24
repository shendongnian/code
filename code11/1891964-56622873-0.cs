    public class Department
    {
        public int DepartmentId { get; private set; }
        // ...
        public virtual ICollection<Employee> Employees { get; private set; } = new List<Employee>();
    }
