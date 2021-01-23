    public class Person
    {
      public string Name {get;set;}
      public int? Age {get;set;}
      public bool ShouldSerializeAge()
      {
        return Age.HasValue;
      }
    }
