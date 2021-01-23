    public class PersonMap : ClassMap<Person>
    {
      public PersonMap()
      {
        Schema("alternativeSchema");
      }
    }
