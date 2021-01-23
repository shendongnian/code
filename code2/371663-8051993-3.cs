    public class Person
    {
      public Person(string forename, string surname)
      {
        if (forename == null) throw new ArgumentNullException("forename");
        if (surname == null) throw new ArgumentNullException("surname");
        
        Forename = forename;
        Surname = surname;
      }
        
      public string Forename { get; private set; }
      public string Surname { get; private set; }
      
      public string Initial { get; set; }
    }
