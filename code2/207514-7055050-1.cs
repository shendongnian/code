    public class MyModel
    {
      public Name Name { get; set; }
    }
    
    public class Name
    {
      public string First { get; set; }
      public string Last { get; set; }
    }
    
    var model = new MyModel();
    var firstName = model.SafeInvoke(x => x.Name.First, "john");
    var lastName = model.SafeInvoke(x => x.Name.Last, "doe");
    
    Console.WriteLine("{0}, {1}", lastName, firstName)
    // prints: "doe, john"
