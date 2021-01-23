    public class Person
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public short Age { get; set; }
        public Person()
        {
        }
        public Person( Persistence.Person src )
        {
          this.Surname = src.surname;
          this.Name = src.name;
          this.Age = src.age;
        }
    }
    
    ...
    public List<People> LoadPeople()
    {
        using( var context = this.CreateContext() )
        {
            var personQuery = from p in context.Persons
                              select new Person( p );
    
            return personQuery.ToList();
    
        }
    }
