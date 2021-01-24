csharp
public class Department
{
    private int _departmentId { get; set; }
    public string DepartmentName { get; set; }
    private ICollection<Employee> _employees { get; set; }
}
public class Employee
{
    private int _employeeId { get; set; }
    public Department Department;
}
and now in your `DbContext` class
csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Department>().HasKey("_departmentId");
    modelBuilder.Entity<Department>().Property<int>("_departmentId");
    modelBuilder.Entity<Department>(c =>
        c.HasMany(typeof(Employee), "_employees")
            .WithOne("Department")
    );
    modelBuilder.Entity<Employee>().HasKey("_employeeId");
    base.OnModelCreating(modelBuilder);
}
**Entity framework 6.2.0**
csharp
public class Employee
{
    private int _employeeId { get; set; }
    public Department Department { get; set; }
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(d => d._employeeId);
        }
    }
}
public class Department
{
    private int _departmentId { get; set; }
    public string DepartmentName { get; set; }
    private ICollection<Employee> _employees { get; set; }
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            HasKey(d => d._departmentId);
            Property(d => d._departmentId);
            HasMany(d => d._employees).WithOptional(e => e.Department);
        }
    }
}
and now in your `DbContext` class 
csharp
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Configurations
        .Add(new Department.DepartmentConfiguration())
        .Add(new Employee.EmployeeConfiguration());
    base.OnModelCreating(modelBuilder);
}
I had tried this code and it works.
