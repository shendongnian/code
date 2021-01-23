    public class ClassA
    {
      public int? Id {get; set;}
      public string Name { get; set;}
      public int BId {get;set;} // foreign key to B
      public virtual ClassB B {get; set;}
    }
