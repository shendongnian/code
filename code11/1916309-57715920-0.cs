    class Base
    {
      private static int x;
      class Derived : Base
      {
          static void M() { Console.WriteLine(Base.x); } 
      }
    }
