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
    
          // a can happily hold references for B.
          a = b;
          // To call B's methods you need to cast it to B.
          ((B)a).b();
    
          // a can happily hold references for C.
          a = c;
          // To call C's methods you need to cast it to C.
    
          a = c;
          ((C)a).c(); 
        }
    }
