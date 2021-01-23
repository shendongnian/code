    public class PersonContext : DbContext
    {
        public PersonContext()  : base("UnicornsCEDatabase")
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
    public class Person
    {
        public int PersonId { get; set; }
        public int NameId { get; set; }
        public string Name { get; set; }
    }
    public class Program
        {
            static void Main(string[] args)
            {
                using (var db = new PersonContext())
                {
                    db.Database.Delete();
                    //Try to create table
                    DbSet per = db.Set<Person>();
                    var per1 = new Person { NameId = 1, Name = "James" };
                    per.Add(per1);
                    int recordsAffected = db.SaveChanges();
                    Console.WriteLine(
                        "Saved {0} entities to the database, press any key to exit.",
                        recordsAffected);
                    Console.ReadKey();
                }
            }
        }
    
}
