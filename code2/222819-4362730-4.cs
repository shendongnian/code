    public class Person 
    {
        [Key]
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string SurName { get; set; }
    }
 
    public class User : Person 
    {        
        public string CreatedOn { get; set; }
    }
    public class PersonDBContext : DbContext 
    {
        public DbSet<Person> UserSet { get; set; }        
    }
