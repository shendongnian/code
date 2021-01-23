    namespace ConsoleApplication5
    {
    
      class Program
      {
        interface A { }
        interface B :A { void b(); } // B inherits from A
        interface C :A { void c(); } // C also inherits from A
    
        static void Main()
        {
          // declare vars
          A a = null;
          B b = null;
          C c = null;
          // a can happily hold references for both B and C.
          a = b;
          a = c;
    
          // To call methods you need to cast them to respect type.
          ((B)a).b();
          ((C)a).c();
    
          
        }
    
      }
    }
