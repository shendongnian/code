    public class Person
    {
      // So this is "Static Inforamtion"
      public static int StaticInformation()
      {
        return 1;
      }
      // instance method
      public static int InstanceMethod()
      {
        return StaticInformation();
      }
    }
    public static class StaticClass
    {
      public static int StaticContext()
      {
        return Person.InstanceMethod();
      }
    }
