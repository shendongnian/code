    class Person {
      static public Dictionary<string, Person> Persons  {get; set;};
    
      public string Name {get; set; }
    
      public Person() 
      {
        if ( null == Persons ) Persons = new Dictionary<string, Person>();
      }
    }
    
    // Not tested, but shoud work
    Person.Persons("dave")?.Name
