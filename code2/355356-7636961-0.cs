    public partial class Entities
    {
       internal DbSet<Employee> EmployeeSet { get; set; }
    
       public Entities()
       {
           EmployeeSet = Set<Employee>();
       }
    }
