    public class Employee
    {
      public string Name { get; set; }
      public Employee Manager { get; set; }
    
      public bool ShouldSerializeManager()
      {
        return (Manager != this);
      }
    }
