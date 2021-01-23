    class Program 
    {
      static void Main(string[] args)
      {      
        D.M();
      }      
    }
    class B 
    { 
      static B() { Console.WriteLine("B"); }
      public static void M() {}
    } 
    class D: B 
    { 
      static D() { Console.WriteLine("D"); }
    }
