    public class MyClass
    {
      private readonly int age = 27; // Valid, initialisation.
    }
    public class MyClass
    {
      private readonly int age;
      
      public MyClass() 
      {
        age = 27; // Valid, construction.
      }
    }
    public class MyClass
    {
      private readonly int age;
      
      public int Age { get { return age; } set { age = value; } } // Invalid, it's a readonly field.
    }
