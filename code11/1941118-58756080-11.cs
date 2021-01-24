    public class Person
    {
      public int id;
      public string SSN;
      public string Firstname;
      public string Lastname;
      public DateTime? Birthdate;
    }
    var persons = new List<Person>();
    persons.Add(new Person { id = 1, Firstname = "a", Lastname = "a", Birthdate = null, SSN = "1" });
    persons.Add(new Person { id = 2, Firstname = "b", Lastname = "b", Birthdate = null, SSN = "1" });
    persons.Add(new Person { id = 3, Firstname = "a", Lastname = "a", Birthdate = null, SSN = "1" });
