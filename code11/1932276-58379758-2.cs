    public class A
    {
      // One way is to create an attribute for signaling a property to inject
      [MyDIFrameworkAttributeForPropertyInjection]
      public B B1 { get; set; }
      // Another way is to use reflection to loop through all properties
      // and if a Type is found in the container, inject it after instantiation
      public B B2 { get; set; }
      
      public A()
      {
        // WARNING, B1 AND B2 WILL ALWAYS BE NULL
        // IN THE CONSTRUCTOR AND ANY METHOD THE CONSTRUCTOR CALLS
        // BECAUSE IT CANNOT BE ASSIGNED UNTIL THE CLASS IS CREATED
      }
    }
