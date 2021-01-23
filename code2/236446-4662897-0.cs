    interface IWrite 
    { 
     void Write(); 
    }
    class A : IWrite { 
      public void Write() { Console.WriteLine("A"); } 
    }
    class B : IWrite { 
      public void Write() { Console.WriteLine("B"); } 
    }
    class X : IWrite { 
      private readonly string _x;
      public X(string x) {
        _x = x;
      } 
      public void Write() { Console.WriteLine(_x); } 
    }
    
    class UseIWrite()
    {
      public void Use(IWrite iwrite) 
      {
         iwrite.Write();
      }
    }
