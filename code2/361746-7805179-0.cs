    var seededPerson = Person.CreateNew();
    public class Person
    {
      private Person() {}
    
      public static Person CreateNew()
      {
        return new Person() { Seed = 123; };
      }
    }
