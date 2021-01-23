    public class File {
        public int Id { get; set; }
        public string Path { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
    public class Event {
        public int Id { get; set; }
        public string EventName { get; set; }
        public virtual ICollection<File> Files {get;set;}
    }
    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
    public class MyContext : DbContext {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<File> Files { get; set; }
    }
 
