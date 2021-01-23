    using System;
    
    public class Test
    {
      public static void Main()
      {
          Grandchild g = new Grandchild();
      }
    }
    
    class Base
    {
        public int i=10;
    }
    
    class DerivedFromBase : Base
    {
        public DerivedFromBase()
        {
          Console.WriteLine(i);
        }
    }
    
    class Grandchild : DerivedFromBase 
    {
       public Grandchild()
       {
          Console.WriteLine(i);
       }
    }
