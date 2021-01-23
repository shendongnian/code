    public class Person
    
        {
            public int ID { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public string gender { get; set; }
        }
        public class Dog
        {
            public int ID { get; set; }
            public string name { get; set; }
            public string breed { get; set; }
        }
        
        public class ApplicationNameDBContext : DbContext
        {
            public DbSet<Person> People { get; set; }
            public DbSet<Dog> Dogs { get; set; }
        }
