    using System;
    using MySystem;
    namespace MyCode
    {
      public class TestClass
      {
        public static void Test()
        {
          Enum.GetNames(); //error: ambiguous between System and MySystem
        }
      }
    }
