    using System;
    
    class Obj {
       public bool Incremented {get;set;}
       public static Obj operator ++ (Obj o) {
         Console.WriteLine("Increment operator is executed.");
         return new Obj {Incremented = true};
       }
    }
    
    class L {
      public int this[Obj o] {
        set { Console.WriteLine("Assignment called with " + 
                (o.Incremented ? "incremented" : "original") + " indexer value."); }
      }
    
    }
    class Test{
      static void Main() {
        Obj o = new Obj();
        L l = new L();
        l[o++] = Func();
      }
    
      static int Func() {
        Console.WriteLine("Function call.");
        return 10;
      }
    }
