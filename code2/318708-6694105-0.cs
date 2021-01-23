    class Person {
      public Guid Id {get;set;}
      public string Name {get;set;}
      [ForeignKey("Id")]
      public virtual Person Manager {get;set;} 
      public Guid? ManagerId {get;set;}
    }
