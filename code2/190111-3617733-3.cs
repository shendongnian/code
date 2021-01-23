    using System;
    namespace MyCode
    {
      using MySystem; //move using to inside the namespace
      public class TestClass
      {
        public static void Test()
        {
          //will now work, and will target the 'MySystem.Enum.GetNames()'
          //method.
          Enum.GetNames();
        }
      }
    }
