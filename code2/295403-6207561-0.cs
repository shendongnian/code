    public class Parent
    {
      public int FieldA { get; set; }
      public string FieldB { get; set; }
    }
    
    public class Child
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }
    
    public class ParentChildViewModel
    {
      public Parent Master { get; set; }
      public List<Child> Children { get; set; }
    }
