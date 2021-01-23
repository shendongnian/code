    public class DB : IMapper
    {
         public MapperSet<Person> Persons = null;
         public DB()
         {
             Persons = new MapperSet<Person>(this);
         }       
         (...)
    }
