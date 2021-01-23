    public class Person
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public short Age { get; set; }
        public Person()
        {
        }
        public Person( Persistence.Person src )
        {
          this.ID = src.ID;
          this.Surname = src.surname;
          this.Name = src.name;
          this.Age = src.age;
        }
    }
    
    ...
    public List<Domain.Person> LoadPeople()
    {
        using( var context = this.CreateContext() )
        {
            var personQuery = from p in context.Persons
                              select new Domain.Person( p );
    
            return personQuery.ToList();
        }
    }
    public Person LoadPerson( int personID )
    {
        using( var context = this.CreateContext() )
        {
            var personQuery = from p in context.Persons
                              where p.id == personID
                              select new Domain.Person( p );
            return personQuery.SingleOrDefault();
        }
    }
