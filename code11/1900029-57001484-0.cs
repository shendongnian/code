    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }       
        public DateTime DateOfBirth { get; set; }
        public DateTime DateWhenJoined { get; set; }
       
    }
    //In ApplicationDbContext
    public DbSet<Employee> Employees { get; set; }
    
