    public class NestedClass
    {
      public string ClassName {get;set;}
    }
    
    public class Person
    {
      public Person()
      {
        Classes = new List<NestedClass>();
      }  
    
      [BsonId]
      public string PersonId {get;set;}
    
      public string Name {get;set;}
    
      public List<NestedClass> Classes {get;set;}
    }
